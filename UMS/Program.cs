using Microsoft.EntityFrameworkCore;
using UMS.Data;
//using UMS.Models;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.Extensions.Hosting;
//using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options 
            => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Adding bInitializer class to the pipeline
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    var context = services.GetRequiredService<ApplicationDbContext>();
//    DbInitializer.Initialize(context);
//}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
