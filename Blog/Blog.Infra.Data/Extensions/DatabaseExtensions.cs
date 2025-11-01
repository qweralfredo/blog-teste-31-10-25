using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Blog.Infra.Data.Extensions
{
    public static class DatabaseExtensions
    {
        /// <summary>
   /// Garante que o banco seja criado e populado com dados iniciais
/// </summary>
        public static async Task EnsureDatabaseSeededAsync(this IServiceProvider serviceProvider)
        {
    using var scope = serviceProvider.CreateScope();
          var context = scope.ServiceProvider.GetRequiredService<Context>();
            var logger = scope.ServiceProvider.GetService<ILogger<Context>>();

  try
      {
           // Para InMemory database, apenas garantir que existe
          await context.Database.EnsureCreatedAsync();
       
    logger?.LogInformation("Database seeded successfully");
     }
            catch (Exception ex)
            {
     logger?.LogError(ex, "An error occurred while seeding the database");
      throw;
    }
   }

        /// <summary>
        /// Versão síncrona para casos onde async não é possível
     /// </summary>
        public static void EnsureDatabaseSeeded(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<Context>();
            
            // Para InMemory database, apenas garantir que existe
context.Database.EnsureCreated();
        }
    }
}