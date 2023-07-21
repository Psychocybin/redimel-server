using Microsoft.EntityFrameworkCore;
using redimel_server.Data;
using redimel_server.Mappings;
using redimel_server.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RedimelServerDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("RedimelServerConnectionString")));

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

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
