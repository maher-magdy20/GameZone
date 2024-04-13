

using GameZone.Services;

var builder = WebApplication.CreateBuilder(args);

var connectionStrings = builder.Configuration.GetConnectionString("DefautConnection") 
	?? throw new InvalidOperationException("No connection staing was found");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionStrings));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IDevicesService, DevicesService>();
builder.Services.AddScoped<IGemesServise,  GemesServise>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
