using Microsoft.EntityFrameworkCore;
using Src.Domain.AppService.ManageCar;
using Src.Domain.AppService.ManageRequest;
using Src.Domain.AppService.ManageUser;
using Src.Domain.Core.ManageCar.AppService;
using Src.Domain.Core.ManageCar.Repository;
using Src.Domain.Core.ManageCar.Service;
using Src.Domain.Core.ManageRequest.AppService;
using Src.Domain.Core.ManageRequest.Repository;
using Src.Domain.Core.ManageRequest.Service;
using Src.Domain.Core.ManageUser.AppService;
using Src.Domain.Core.ManageUser.Repository;
using Src.Domain.Core.ManageUser.Service;
using Src.Domain.Service.ManageCar;
using Src.Domain.Service.ManageRequest;
using Src.Domain.Service.ManageUser;
using Src.Infra.DataAccess.repos.Ef.ManageCar;
using Src.Infra.DataAccess.repos.Ef.ManageRequest;
using Src.Infra.DataAccess.repos.Ef.ManageUser;
using Src.Infra.DataBase.SqlServer.Ef.DbContexs;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
string? connectionstring = builder.Configuration.GetConnectionString("DefultConnection");
builder.Services.AddDbContext<AppointmentDbContext>(options => options.UseSqlServer(connectionstring));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<ICarAppService, CarAppService>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<IRequestAppService, RequestAppService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
