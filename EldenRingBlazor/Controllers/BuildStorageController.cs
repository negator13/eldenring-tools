using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using EldenRingBlazor.Data.BuildPersistence;
using Microsoft.AspNetCore.Mvc;

namespace EldenRingBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildStorageController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly SaveBuildService _saveBuildService;

        public BuildStorageController(IConfiguration configuration, SaveBuildService saveBuildService)
        {
            _connectionString = configuration.GetConnectionString("AzureConnectionString");
            _saveBuildService = saveBuildService;
        }

        [HttpPost]
        public async Task<IActionResult> Upload()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                if (file.Length > 0)
                {
                    var container = new BlobContainerClient(_connectionString, "builds");
                    var createResponse = await container.CreateIfNotExistsAsync();
                    if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                    {
                        await container.SetAccessPolicyAsync(PublicAccessType.Blob);
                    }
                    var blob = container.GetBlobClient(file.FileName);
                    await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);
                    using (var fileStream = file.OpenReadStream())
                    {
                        await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = file.ContentType });
                    }
                    return Ok(blob.Uri.ToString());
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
