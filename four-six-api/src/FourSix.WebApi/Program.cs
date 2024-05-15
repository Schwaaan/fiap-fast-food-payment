using FourSix.Controllers.Gateways.DataAccess;
using FourSix.Controllers.Middlewares;
using FourSix.WebApi.Modules;
using FourSix.WebApi.Modules.Commons;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using Amazon.Extensions.CognitoAuthentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAdapters();
builder.Services.AddDatabase();
builder.Services.AddUseCases();
builder.Services.AddCustomControllers();
builder.Services.AddCustomCors();
builder.Services.AddSwaggerConfig();
builder.Services.AddCognitoIdentity();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["AWSCognito:Authority"];
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false
    };
});

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
});
builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
});
builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
});

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<Context>();
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
                    options =>
                    {
                        var swaggerEndpoint = $"/swagger/v1/swagger.json";
                        options.SwaggerEndpoint(swaggerEndpoint, "v1");
                        options.DisplayRequestDuration();
                    });
}

app.UseMiddleware<CustomHttpContextMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.AddRoutesMaps();

app.MapControllers();

app.Run();