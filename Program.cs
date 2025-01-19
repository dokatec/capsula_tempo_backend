using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PostDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c => c.RouteTemplate = "api-docs/{documentName}/swagger.json");
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/api-docs/v1/swagger.json", "My API v1"));
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

