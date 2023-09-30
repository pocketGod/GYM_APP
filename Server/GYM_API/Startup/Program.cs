using DatabaseBootstrapLibrary;
using GYM_API.Startup.Configurations;

var builder = WebApplication.CreateBuilder(args);

// General Configuration
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

// DB Configuration
DatabaseBootstrap.Initialize(builder.Services, builder.Configuration);

// Various Injections Configuration
builder.Services.ConfigureAppServices(builder.Configuration);

// Swagger Configuration
builder.Services.ConfigureSwagger();

WebApplication app = builder.Build();


CorsConfiguration.UseCorsConfiguration(app);
MiddlewareConfiguration.UseMiddlewareConfiguration(app);

// Swagger config (only in Development)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
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
