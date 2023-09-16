using MaxTechCS.Data.Global;
using MaxTechCS.Data.Global.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var settingsSection = builder.Configuration.GetSection("Settings");

Configuration.RandomApiUrl = builder.Configuration.GetValue<string>("RandomApi");
Configuration.BlackList = settingsSection.GetSection("BlackList").Get<List<string>>();
ParallelVariables.ParallelLimit = settingsSection.GetValue<int>("ParallelLimit");

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
