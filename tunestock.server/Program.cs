using System.Net.Http.Headers;
using Blazored.Toast;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using tunestock.server.Data;
using tunestock.server.Services.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using tunestock.server.Services.Label;
using tunestock.server.Services.Sound;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddRazorComponents();
builder.Services.AddScoped<DialogService>();

builder.Services.AddSingleton<WeatherForecastService>();


builder.Services.AddSingleton<UserSession>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISoundService, SoundService>();
builder.Services.AddScoped<ILabelService, LabelService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();