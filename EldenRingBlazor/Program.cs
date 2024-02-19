using EldenRingBlazor.Services.AttackRating;
using EldenRingBlazor.Services.BuildPersistence;
using EldenRingBlazor.Services.BuildPlanner;
using EldenRingBlazor.Services.CalcCorrect;
using EldenRingBlazor.Services.Equipment;
using EldenRingBlazor.Services.ItemDrops;
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
builder.Services.AddSingleton<ArmorEffectsService>();
builder.Services.AddSingleton<WeaponEffectsService>();
builder.Services.AddSingleton<TalismanService>();
builder.Services.AddSingleton<SaveBuildService>();
builder.Services.AddSingleton<NpcItemDropService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
