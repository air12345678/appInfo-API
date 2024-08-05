using appInfo.api.BLL.Implementation;
using appInfo.api.common.models;
using appInfo.api.DAL.Implementation;
using appInfo.API.BLL.Interfaces;
using appInfo.API.DAL.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
var builder = WebApplication.CreateBuilder(args);
IConfigurationRoot configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddEnvironmentVariables().Build();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<AppInfoDatabaseSettings>(builder.Configuration.GetSection("AppInfoDatabaseSettings"));

builder.Services.AddScoped<ITechStackBAL, TechStackBAL>();
builder.Services.AddScoped<ITechStackDAL, TechStackDAL>();
builder.Services.AddSingleton(configuration);

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();


// builder.Services.AddSingleton<IMongoClient>(_ => {
//     var connectionString = 
//         builder
//             .Configuration
//             .GetSection("AppInfoDatabaseSettings:ConnectionString")?
//             .Value;
//     return new MongoClient(connectionString);
// });
// Configure the HTTP request pipeline.


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use CORS
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
