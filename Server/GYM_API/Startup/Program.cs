using DatabaseBootstrapLibrary;
using GYM_API.Middlewares;
using GYM_DB.Repositories;
using GYM_LOGICS.Builders;
using GYM_LOGICS.Managers;
using GYM_LOGICS.Services;
using GYM_MODELS.Settings;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using System.Reflection;
using static GYM_MODELS.Settings.Swagger;

var builder = WebApplication.CreateBuilder(args);

// General Configuration
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

// Dependency Injections
// DB
DatabaseBootstrap.Initialize(builder.Services, builder.Configuration);
// Services
builder.Services.AddScoped<JWTService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<PropertiesService>();
builder.Services.AddScoped<ExerciseService>();
builder.Services.AddScoped<WorkoutService>();
builder.Services.AddScoped<WorkoutPlanService>();
// Managers
builder.Services.AddScoped<WorkoutManager>();
builder.Services.AddScoped<PropertiesManager>();
// Builders
builder.Services.AddScoped<ExerciseBuilder>();
builder.Services.AddScoped<WorkoutBuilder>();
builder.Services.AddScoped<WorkoutPlanBuilder>();
// JWT
builder.Services.AddSingleton(builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>());
// Swagger Auth 
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GYM API", Version = "v1" });

    // XML Comments and Annotations
    string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    c.EnableAnnotations();

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

WebApplication app = builder.Build();

// Cors config
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .WithMethods("GET", "POST", "PUT")
    .AllowAnyHeader()
    );

// Middlewares
app.UseMiddleware<TokenMiddleware>();
app.UseMiddleware<ApiResponseMiddleware>();

// Swagger config
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(c =>
    {
        c.PreSerializeFilters.Add((swaggerDoc, httpReq) =>
        {
            var orderedTags = new List<OpenApiTag>
        {
            new OpenApiTag { Name = nameof(ApiGroupNames.Authentication), Description = "Requests for user authentication" },
            new OpenApiTag { Name = nameof(ApiGroupNames.DataRetrieval), Description = "Requests for data retrieval" },
            new OpenApiTag { Name = nameof(ApiGroupNames.WorkoutCreation), Description = "Requests for creating workouts" },
            new OpenApiTag { Name = nameof(ApiGroupNames.Misc), Description = "Miscellaneous requests" },
        };
            swaggerDoc.Tags = orderedTags;
        });
    });
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GYM API v1");
    });
}


// General App Configuration
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();