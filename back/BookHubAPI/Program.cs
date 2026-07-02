using BookHubAPI.DataBase;
using BookHubAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<LivrosService>();

builder.Services.AddDbContext<AppDbContext> (options =>
{
   var connectionSting = builder.Configuration.GetConnectionString("DefaultConnection") 
   ?? throw new InvalidOperationException ("Conection String não encontrada"); 

    options.UseMySql(connectionSting, ServerVersion.AutoDetect(connectionSting));
});

var app = builder.Build();
app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapSwagger();
    app.MapSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

