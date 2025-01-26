using Api;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));

builder.Services
    .AddCarterWithAssemblies(typeof(CatalogModule).Assembly);

// Add services to the container.
builder.Services
    .AddCatalogModule(builder.Configuration)
    .AddBasketModule(builder.Configuration)
    .AddOrderingModule(builder.Configuration)
    .AddStartupConfigration();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();

app
    .UseStartupConfigration()
    .UseCatalogModule()
    .UseBasketModule()
    .UseOrderingModule();

app.Run();