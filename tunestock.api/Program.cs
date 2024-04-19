//Importamos nuestros paquetes
using tunestock.api.dataAccess.interfaces;
using tunestock.api.repositories;
using tunestock.api.repositories.interfaces;
using tunestock.api.services;
using tunestock.api.services.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDbContext, DbContext>();

builder.Services.AddScoped<ILabelRepository, LabelRepository>();
builder.Services.AddScoped<IUserDownloadRepository, UserDownloadRepository>();
builder.Services.AddScoped<IUserPurchaseRepository, UserPurchaseRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISoundRepository, SoundRepository>();

builder.Services.AddScoped<ILabelService, LabelService>();
builder.Services.AddScoped<IUserDownloadService, UserDownloadService>();
builder.Services.AddScoped<IUserPurchaseService, UserPurchaseService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISoundService, SoundService>();

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
