namespace Api;

public static class StartupConfigration
{
    public static IServiceCollection AddStartupConfigration(this IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.AddExceptionHandler<CustomExceptionHandler>();
        

        return services;
    }

    public static IApplicationBuilder UseStartupConfigration(this IApplicationBuilder app)
    {
        var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();

        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopify V1");
                options.RoutePrefix = string.Empty;
            });
        }

        app.UseSerilogRequestLogging();
        app.UseExceptionHandler(options => { });

        return app;
    }
}
