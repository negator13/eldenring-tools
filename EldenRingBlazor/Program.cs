using EldenRingBlazor.Data.AttackRating;
using EldenRingBlazor.Data.BuildPlanner;
using EldenRingBlazor.Data.CalcCorrect;
using EldenRingBlazor.Data.Equipment;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

//var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
//builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddMudServices();

builder.Services.AddSingleton<EquipmentService>();
builder.Services.AddSingleton<AttackRatingCalculationService>();
builder.Services.AddSingleton<BuildPlannerService>();
builder.Services.AddSingleton<CalcCorrectService>();
builder.Services.AddSingleton<TalismanService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
