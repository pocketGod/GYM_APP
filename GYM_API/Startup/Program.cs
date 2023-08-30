using GYM_LOGICS.Managers;
using GYM_LOGICS.Services;
using GYM_MODELS.Settings;
using MongoDB.Driver;


var builder = WebApplication.CreateBuilder(args);

// Dependency Injections
// Managers
builder.Services.AddScoped<WorkoutManager>();
builder.Services.AddScoped<PropertiesManager>();
// Services
builder.Services.AddScoped<PropertiesService>();
builder.Services.AddScoped<ExerciseService>();
builder.Services.AddScoped<WorkoutService>();

// MongoDB Injections
var mongoDbSettings = builder.Configuration.GetSection("MongoDB").Get<MongoDBSettings>();
builder.Services.AddSingleton<IMongoClient>(serviceProvider => new MongoClient(mongoDbSettings.ConnectionString));
builder.Services.AddSingleton(serviceProvider => serviceProvider.GetRequiredService<IMongoClient>().GetDatabase(mongoDbSettings.DatabaseName));


// General Builder Configuration
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

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