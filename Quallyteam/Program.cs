using Microsoft.EntityFrameworkCore;
//using MySql.Data.EntityFrameworkCore.Infrastructure;
using Quallyteam.DataB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
//builder.Services.AddDbContext<DataC>
//    (options => options.UseMySql("server=127.0.0.1;initial database=documentos; uid=root; pwd=;",
//                Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql")));



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
