using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Src.Domain.Entity
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        // Método OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cargar todas las entidades dinámicamente usando Reflection
            var entityTypes = Assembly.GetExecutingAssembly()
                                      .GetTypes()
                                      .Where(t => t.IsClass && !t.IsAbstract && t.Namespace == "MiProyecto.Models")
                                      .Where(t => typeof(BaseEntity).IsAssignableFrom(t));  // Si todas las entidades heredan de una clase base

            foreach (var entityType in entityTypes)
            {
                // Registra cada entidad en el modelo
                modelBuilder.Entity(entityType);
            }
        }
    }
}
