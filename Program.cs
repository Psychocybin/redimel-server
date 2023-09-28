using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using redimel_server.Data;
using redimel_server.Mappings;
using redimel_server.Middlewares;
using redimel_server.Repositories;
using Serilog;
using System.Collections;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/redimel-server_log.txt", rollingInterval: RollingInterval.Day)
    .MinimumLevel.Warning()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Redimel Server API", Version = "v1" });
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = JwtBearerDefaults.AuthenticationScheme
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                },
                Scheme = "Oauth2",
                Name = JwtBearerDefaults.AuthenticationScheme,
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});

builder.Services.AddDbContext<RedimelServerDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("RedimelServerConnectionString")));

builder.Services.AddDbContext<RedimelServerAuthDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("RedimelServerAuthConnectionString")));

builder.Services.AddScoped<IIndicatorRepository, SQLIndicatorRepository>();
builder.Services.AddScoped<IBaggageRepository, SQLBaggageRepository>();
builder.Services.AddScoped<INatureSkillRepository, SQLNatureSkillRepository>();
builder.Services.AddScoped<IAbilityRepository, SQLAbilityRepository>();
builder.Services.AddScoped<IAditionalPointRepository, SQLAditionalPointRepository>();
builder.Services.AddScoped<IArmorRepository, SQLArmorRepository>();
builder.Services.AddScoped<IEquipmentRepository, SQLEquipmentRepository>();
builder.Services.AddScoped<IHeroRepository, SQLHeroRepository>();
builder.Services.AddScoped<IMissionRepository, SQLMissionRepository>();
builder.Services.AddScoped<INegotiationRepository, SQLNegotiationRepository>();
builder.Services.AddScoped<IPromiseRepository, SQLPromiseRepository>();
builder.Services.AddScoped<IRitualRepository, SQLRitualRepository>();
builder.Services.AddScoped<IShieldRepository, SQLShieldRepository>();
builder.Services.AddScoped<ISpecialCombatSkillRepository, SQLSpecialCombatSkillRepository>();
builder.Services.AddScoped<ISpellRepository, SQLSpellRepository>();
builder.Services.AddScoped<ITalismanRepository, SQLTalismanRepository>();
builder.Services.AddScoped<IThrowingWeaponRepository, SQLThrowingWeaponRepository>();
builder.Services.AddScoped<IUltimateRepository, SQLUltimateRepository>();
builder.Services.AddScoped<IWeaponRepository, SQLWeaponRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();
builder.Services.AddScoped<IImageRepository, LocalImageRepository>();
builder.Services.AddScoped<IUserRepository, SQLUserRepository>();
builder.Services.AddScoped<IStartGameRepository, SQLStartGameRepository>();
builder.Services.AddScoped<IPageRepository, SQLPageRepository>();
builder.Services.AddScoped<IChoiceRepository, SQLChoiceRepository>();
builder.Services.AddScoped<IAuxiliaryRepository, SQLAuxiliaryRepository>();
builder.Services.AddScoped<IRedimelInfoRepository, SQLRedimelInfoRepository>();
builder.Services.AddScoped<IChangeRepository, SQLChangeRepository>();


builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("redimel-server")
    .AddEntityFrameworkStores<RedimelServerAuthDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 1;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = "/Images"
});

app.MapControllers();

app.Run();
