// EduSync/Program.cs

using Microsoft.EntityFrameworkCore;
using EduSync.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<EduSync.Services.EventHubSender>();

// CORS policy name
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Configure DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EduSyncDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add CORS services and policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins(
                "http://localhost:3000", // for local development
                "https://polite-sand-06a25f500.6.azurestaticapps.net" // your deployed frontend
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<EduSync.Services.BlobStorageService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Correct middleware order: UseCors before UseAuthorization
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
