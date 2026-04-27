using Microsoft.EntityFrameworkCore;
using StudentCoursesApi.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Handle potential circular references in the entity relationships
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Register Entity Framework Core with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register NSwag/OpenAPI services.
builder.Services.AddOpenApiDocument(ConfigurationBinder =>
{
    ConfigurationBinder.Title = "Student Courses API";
    ConfigurationBinder.Version = "v1";
    ConfigurationBinder.Description = "Final project Web API using .NET 10, Entity Framework Core, Code First migrations, seed data, and NSwag.";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
