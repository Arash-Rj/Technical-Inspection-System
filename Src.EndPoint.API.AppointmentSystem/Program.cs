using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Src.Domain.AppService.ManageCar;
using Src.Domain.AppService.ManageRequest;
using Src.Domain.AppService.ManageUser;
using Src.Domain.Core.Configs;
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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var dayLimitaions = builder.Configuration.GetSection("DayLimitaions").Get<DayLimitaions>();
builder.Services.AddSingleton(dayLimitaions);
var ApiKey = builder.Configuration.GetSection("Apikey").Get<ApiKey>();
builder.Services.AddSingleton(ApiKey);
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

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
