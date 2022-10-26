using Chat.Data;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure
{
    public static class ApplicationBuilderExtension
    {

        public static async Task<IApplicationBuilder> PrepareDatabase( this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            var db = services.GetRequiredService<ApplicationDbContext>();
            db.Database.Migrate();
        }

    }
}
