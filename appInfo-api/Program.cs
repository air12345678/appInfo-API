using appInfo.api.BLL.Implementation;
using appInfo.api.common.models;
using appInfo.api.DAL.Implementation;
using appInfo.API.BLL.Interfaces;
using appInfo.API.DAL.Interfaces;

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
builder.Services.Configure<AzureBlobSettings>(builder.Configuration.GetSection("AzureBlobSettings"));
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));


builder.Services.AddScoped<ITechStackBAL, TechStackBAL>();
builder.Services.AddScoped<ITechStackDAL, TechStackDAL>();
builder.Services.AddScoped<IFileUploadBAL, FileUploadBAL>();
builder.Services.AddScoped<IFileUploadDAL, FileUploadDAL>();
builder.Services.AddScoped<IApplicationDetailBAL, ApplicationInfoDetailBAL>();
builder.Services.AddScoped<IApplicationDetailDAL, ApplicationInfoDetailDAL>();

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

app.UseSwagger();

app.UseSwaggerUI(x =>
{
    x.SwaggerEndpoint("/swagger/v1/swagger.json", "appInfo-api V1");

if(app.Environment.IsDevelopment())
    x.RoutePrefix = "swagger"; 
else
    x.RoutePrefix = string.Empty;
}
);

app.UseSwagger();

// Use CORS
app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
