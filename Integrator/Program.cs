using Integrator.Configuration;
using Integrator.Configuration.Settings;

var builder = WebApplication.CreateBuilder(args);

ApplicationSettings settings = builder.Services.RegisterSettings();

builder.Services.AddControllers();
builder.Services.RegisterSwagger();
builder.Services.RegisterHangfire(settings.ConnectionStrings, settings.HangfireSettings);

var app = builder.Build();

app.AddSwagger();
app.UseCors(config => config.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.AddHangfireDashboard();

Console.WriteLine("integrator works! :D");

app.Run();
