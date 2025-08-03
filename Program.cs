using KassaPro.Data.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
var serverVersion = new MySqlServerVersion(new Version(10, 4, 32));
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<PosContext>(options => options
        .UseMySql(builder.Configuration
        .GetConnectionString("DefaultConnection"),serverVersion));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()||app.Environment.IsProduction())
{
    app.MapOpenApi();
}
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "Open API - Swagger");
});
app.UseHttpsRedirection();
app.MapControllers();
app.Run();