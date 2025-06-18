using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProveedorScreeningAPI.Data;
using ProveedorScreeningAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexión y el contexto de la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar Identity para el usuario
builder.Services.AddIdentity<Usuario, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Obtener la clave secreta desde appsettings.json
var secretKey = builder.Configuration["JwtSettings:SecretKey"];
var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

// Configuración de autenticación JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "Bearer";
    options.DefaultChallengeScheme = "Bearer";
})
.AddJwtBearer("Bearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = signingKey
    };
});

// Configura CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost",
        builder => builder.WithOrigins("http://localhost:3000")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddControllers();

var app = builder.Build();

// Habilitar CORS
app.UseCors("AllowLocalhost");

// Llamar al método de Seed para insertar un usuario admin si no existe
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    var userManager = services.GetRequiredService<UserManager<Usuario>>();
    await ApplicationDbContextSeed.SeedAsync(context, userManager);
}

app.UseHttpsRedirection();

// Usar autenticación y autorización
app.UseAuthentication(); // Usar autenticación
app.UseAuthorization(); // Usar autorización

app.MapControllers();

app.Run();
