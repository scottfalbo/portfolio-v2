using Portfolio.MechanistTower.Configurations;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

ConfigurationRituals.TuningRune(builder, configuration);

var app = builder.Build();

ConfigurationRituals.ImbueConstruct(app);

app.Run();