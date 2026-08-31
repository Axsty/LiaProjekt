using LiaProjekt.Models;
using LiaProjekt.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Host=ep-shy-rain-b1njh6yc-pooler.c-5.eu-central-1.aws.neon.tech; Database=neondb; Username=neondb_owner; Password=npg_OE2jBUD4sifa; SSL Mode=Require;";

builder.Services.AddDbContext<MyDbContext>(options =>
options.UseNpgsql(connectionString));

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<QuoteService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("https://glittery-wisp-a39f48.netlify.app/")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
