using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Přidání MVC
builder.Services.AddControllersWithViews();

// Připojení k databázi
builder.Services.AddDbContext<Ukolnicek.Data.ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Prostředí vývoje
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Standardní routování
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
