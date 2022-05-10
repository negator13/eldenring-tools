using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using EldenRingBlazor.Data.BuildPlanner;
using EldenRingBlazor.Data.Equipment;
using Newtonsoft.Json;
using System.Text;

namespace EldenRingBlazor.Data.BuildPersistence
{
    public class SaveBuildService
    {
        private readonly string _connectionString;
        private readonly EquipmentService _equipmentService;

        public SaveBuildService(IConfiguration configuration, EquipmentService equipmentService)
        {
            _connectionString = configuration.GetConnectionString("AzureConnectionString");
            _equipmentService = equipmentService;
        }

        public async Task<string> SaveBuild(BuildPlannerInput input)
        {
            if (input.BuildId != null)
            {
                var existingBuild = await LoadBuild(input.BuildId);

                if (existingBuild != null && existingBuild.Name != input.Name)
                {
                    input.BuildId = Guid.NewGuid().ToString();
                }
            }
            else
            {
                input.BuildId = Guid.NewGuid().ToString();
            }

            // Serialize input
            var serializedBuild = input.Serialize();

            // Save to blob storage
            await Upload(serializedBuild);

            //var deserializedInput = Deserialize(serializedBuild);

            return input.BuildId;
        }

        private async Task Upload(SerializedBuildInput input)
        {
            var container = new BlobContainerClient(_connectionString, "builds");
            var createResponse = await container.CreateIfNotExistsAsync();
            if (createResponse != null && createResponse.GetRawResponse().Status == 201)
            {
                await container.SetAccessPolicyAsync(PublicAccessType.Blob);
            }

            var blob = container.GetBlobClient(input.BuildId);
            await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);

            var json = JsonConvert.SerializeObject(input);

            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                await blob.UploadAsync(ms);
            }
        }

        public async Task<BuildPlannerInput> LoadBuild(string buildId)
        {
            // Retrieve serialized input from blob storage
            var container = new BlobContainerClient(_connectionString, "builds");
            var blob = container.GetBlobClient(buildId);

            SerializedBuildInput serializedBuild;

            using (var stream = await blob.OpenReadAsync())
            using (var sr = new StreamReader(stream))
            using (var jr = new JsonTextReader(sr))
            {
                serializedBuild = JsonSerializer.CreateDefault().Deserialize<SerializedBuildInput>(jr);
            }

            // Hydrate into BuildPlannerInput
            var input = Deserialize(serializedBuild);

            return input;
        }

        private BuildPlannerInput Deserialize(SerializedBuildInput input)
        {
            var data = new BuildPlannerInput(_equipmentService);

            data.BuildId = input.BuildId;
            data.Name = input.Name;
            data.StartingClass = _equipmentService.StartingClasses.FirstOrDefault(c => c.Name == input.StartingClass) ?? _equipmentService.StartingClasses.Single(c => c.Name == "Vagabond");

            data.Vigor = input.Vigor;
            data.Mind = input.Mind;
            data.Endurance = input.Endurance;
            data.Strength = input.Strength;
            data.Dexterity = input.Dexterity;
            data.Intelligence = input.Intelligence;
            data.Faith = input.Faith;
            data.Arcane = input.Arcane;

            data.TwoHand = input.TwoHand;

            data.Talisman1 = _equipmentService.Talismans.FirstOrDefault(t => t.Name == input.Talisman1);
            data.Talisman2 = _equipmentService.Talismans.FirstOrDefault(t => t.Name == input.Talisman2);
            data.Talisman3 = _equipmentService.Talismans.FirstOrDefault(t => t.Name == input.Talisman3);
            data.Talisman4 = _equipmentService.Talismans.FirstOrDefault(t => t.Name == input.Talisman4);

            data.Head = _equipmentService.Armor.FirstOrDefault(t => t.EquipSlot == "Head" && t.Name == input.Head);
            data.Chest =  _equipmentService.Armor.FirstOrDefault(t => t.EquipSlot == "Body" && t.Name == input.Chest);
            data.Arms =  _equipmentService.Armor.FirstOrDefault(t => t.EquipSlot == "Arm" && t.Name == input.Arms);
            data.Legs =  _equipmentService.Armor.FirstOrDefault(t => t.EquipSlot == "Leg" && t.Name == input.Legs);

            data.RightWeapon1 = DeserializeWeapon("Right Weapon 1", input.RightWeapon1, input.RightWeapon1Affinity, input.RightWeapon1Level);

            data.RightWeapon2 = DeserializeWeapon("Right Weapon 2", input.RightWeapon2, input.RightWeapon2Affinity, input.RightWeapon2Level);

            data.RightWeapon3 = DeserializeWeapon("Right Weapon 3", input.RightWeapon3, input.RightWeapon3Affinity, input.RightWeapon3Level);

            data.LeftWeapon1 = DeserializeWeapon("Left Weapon 1", input.LeftWeapon1, input.LeftWeapon1Affinity, input.LeftWeapon1Level);

            data.LeftWeapon2 = DeserializeWeapon("Left Weapon 2", input.LeftWeapon2, input.LeftWeapon2Affinity, input.LeftWeapon2Level);

            data.LeftWeapon3 = DeserializeWeapon("Left Weapon 3", input.LeftWeapon3, input.LeftWeapon3Affinity, input.LeftWeapon3Level);

            return data;
        }

        private WeaponSlot DeserializeWeapon(string slotName, string weaponName, int affinityId, int level)
        {
            var slot = new WeaponSlot(slotName, _equipmentService);

            if (weaponName == null)
            {
                return slot;
            }

            slot.WeaponName = weaponName;
            slot.AffinityId = affinityId;
            slot.Level = level;

            slot.UpdateWeapon(weaponName);

            return slot;
        }
    }
}
