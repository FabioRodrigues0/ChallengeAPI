global using ChallengeAPI.Data;
global using ChallengeAPI.Models;
global using ChallengeAPI.Services.DiagonalSumService;
global using ChallengeAPI.Services.RatioSumService;
global using ChallengeAPI.Services.VeryBigSumService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRatioSumService, RatioSumService>();
builder.Services.AddScoped<IVeryBigSumService, VeryBigSumService>();
builder.Services.AddScoped<IDiagonalSumService, DiagonalSumService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();