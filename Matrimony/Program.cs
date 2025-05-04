using Matrimony.Business.Implementation;
using Matrimony.Business.Interface;
using Matrimony.Middlewares;
using Matrimony.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Error()
        .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)  // Logs are written to 'logs/log.txt'
        .CreateLogger();

builder.Host.UseSerilog(); // Use Serilog for logging

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IProfileService, ProfileService>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MatrimonyContext>(options =>
                options.UseSqlServer().EnableSensitiveDataLogging());


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Profiles}/{action=Index}/{id?}");

app.Run();