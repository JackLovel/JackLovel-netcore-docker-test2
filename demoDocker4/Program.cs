using demoDocker4.Db;
using demoDocker4.Repo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<MyDbContext>();
builder.Services.AddScoped<ICompanyRepo, CompanyRepo>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//builder.Services.AddScoped<ISuperHeroRepo, SuperHeroRepo>();
//builder.Services.AddScoped<ICharacterService, CharacterService>();
//builder.Services.AddScoped<ITodoRepo, TodoRepo>();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
