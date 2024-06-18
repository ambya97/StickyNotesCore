using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using StickyNotesCore.Domain.Logic.Repository;

namespace StickyNotesCore.Configurations
{
    public static class ServicesConfiguration
    {
        public const string CORS_POLICY = "ApiCorsPolicy";
        public static void AddNoteServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<INotes, Notes>();
            // CORS options
            var uiBaseAddress = configuration.GetValue<string>("CORS:ClientBaseAddress") ?? throw new ArgumentNullException("cors");
            services.AddCors(options =>
            {
                options.AddPolicy(CORS_POLICY, policy =>
                {
                    policy.WithOrigins(uiBaseAddress).AllowAnyMethod().AllowAnyHeader();
                });
            });
        }
        public static void AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // MediatR
            services.AddMediatR(options => options.RegisterServicesFromAssemblyContaining<Program>());

            // AutoMapper
            services.AddAutoMapper(options => options.AllowNullCollections = true, typeof(Program).Assembly);
        }
        public static void UseMiddlewares(this WebApplication? app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseSwagger().UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Sticky Notes API");
                options.DocumentTitle = "Sticky Notes API";
            });

            app.UseCors(CORS_POLICY);

            if (!app.Environment.IsDevelopment())
            {
                app.UseHttpsRedirection();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.MapControllers();
        }
    }
}
