using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using Zhaso.Entities;
using Zhaso.Interfaces;

namespace Zhaso.Data
{
    public class ZhasoContext : DbContext
    {
        public ZhasoContext(DbContextOptions<ZhasoContext> options)
           : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var context = this;
            base.OnModelCreating(modelBuilder);
            var types = typeof(SeedData).Assembly
               .GetTypes()
               .Where(q => q.GetInterface(typeof(IEntity).FullName) != null);

            foreach (var type in types)
            {
                modelBuilder.Model.GetOrAddEntityType(type);
            }

            var typeConfigs = typeof(SeedData).Assembly
                .GetTypes()
                .Where(q => q.GetInterface(typeof(IEntityTypeConfiguration<>).FullName) != null);

            foreach (var type in typeConfigs)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
    }
}
