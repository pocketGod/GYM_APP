using GYM_API.Middlewares;
using GYM_LOGICS.Builders;
using GYM_LOGICS.Managers;
using GYM_LOGICS.Services;
using GYM_MODELS.Settings;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;


var builder = WebApplication.CreateBuilder(args);

// Dependency Injections
// Services
builder.Services.AddScoped<JWTService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<PropertiesService>();
builder.Services.AddScoped<ExerciseService>();
builder.Services.AddScoped<WorkoutService>();
// Managers
builder.Services.AddScoped<WorkoutManager>();
builder.Services.AddScoped<PropertiesManager>();
// Builders
builder.Services.AddScoped<ExerciseBuilder>();
builder.Services.AddScoped<WorkoutBuilder>();
// MongoDB
MongoDBSettings? mongoDbSettings = builder.Configuration.GetSection("MongoDB").Get<MongoDBSettings>();
builder.Services.AddSingleton<IMongoClient>(serviceProvider => new MongoClient(mongoDbSettings.ConnectionString));
builder.Services.AddSingleton(serviceProvider => serviceProvider.GetRequiredService<IMongoClient>().GetDatabase(mongoDbSettings.DatabaseName));
// JWT
builder.Services.AddSingleton(builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>());
// Swagger Auth 
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "GYM API", Version = "v1" });

    // JWT Authentication
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});
// General Configuration
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

WebApplication app = builder.Build();

// Middlewares
app.UseMiddleware<TokenMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// General App Configuration
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();