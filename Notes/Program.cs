using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Notes.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NotesContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("NotesContext") ?? throw new InvalidOperationException("Connection string 'NotesContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Notes API",
        Description = "An ASP.NET Core Web API for managing Notes",
        Contact = new OpenApiContact
        {
            Name = "Rahma Ahmed",
            Url = new Uri("https://github.com/rahma-samaroon")
        },
        License = new OpenApiLicense
        {
            Name = "MIT",
            Url = new Uri("https://choosealicense.com/licenses/mit/")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
