using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Domain.Ports;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Interfaces;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Interfaces;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Services;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Application.Services;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Persistence;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Persistence;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Repositories;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Repositories;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Security;
using DMSSoftwareDotNET15OCT2025.Recuerdos.Infrastructure.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// ---------------------
// Add services to the container
// ---------------------

// ---------------------
// Add services to the container
// ---------------------

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
        options.JsonSerializerOptions.MaxDepth = 64;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Configurar Swagger para JWT
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Recuerdos API", Version = "v1" });
    var securityScheme = new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Ingrese JWT con Bearer"
    };
    c.AddSecurityDefinition("Bearer", securityScheme);
    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// ---------------------
// Configure DB Context
// ---------------------
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ---------------------
// Dependency Injection
// ---------------------
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<RecuerdoService>();
builder.Services.AddScoped<IRecuerdoRepository, RecuerdoRepository>();
builder.Services.AddScoped<LugarRepository>();
builder.Services.AddScoped<RecuerdoLugarRepository>();
builder.Services.AddScoped<LugarService>();
builder.Services.AddScoped<ObjetoService>();
builder.Services.AddScoped<NotaRepository>();
builder.Services.AddScoped<NotaService>();
builder.Services.AddScoped<PersonaRepository>();
builder.Services.AddScoped<RecuerdoPersonaRepository>();
builder.Services.AddScoped<PersonaService>();





// ---------------------
// JWT Authentication
// ---------------------
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secret = jwtSettings.GetValue<string>("Secret");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.GetValue<string>("Issuer"),
        ValidAudience = jwtSettings.GetValue<string>("Audience"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
        ClockSkew = TimeSpan.Zero
    };
});

// ---------------------
// Enable CORS for Angular dev server
// ---------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev",
        policy => policy
            .WithOrigins("http://localhost:4200") // Angular dev server
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();


// ---------------------
// Configure the HTTP request pipeline
// ---------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS
app.UseCors("AllowAngularDev");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();




// ---------------------
// Configure the HTTP request pipeline
// ---------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
