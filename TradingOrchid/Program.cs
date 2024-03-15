using Application;
using Application.Common.Middleware;
using Infrastructure;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddSwagger()
    .AddAuthen()
    .AddCor()
    .AddDatabase()
    .AddServices()
    .AddRepositories();

// Add AutoMapper
builder.Services.AddAutoMapper(Assembly.Load("Application"));

builder.Services.AddTransient<StorageMiddlewarem>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyCors");

app.UseExceptionHandler("/error");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<StorageMiddlewarem>();

app.Run();
