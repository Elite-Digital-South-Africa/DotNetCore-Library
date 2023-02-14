using Microsoft.EntityFrameworkCore;
using System;

namespace EliteOpenLibrary.Classes
{
    public abstract class EliteDbContext<TType>:DbContext where TType:DbContext
    {
        protected abstract string SchemaName { get; set; }
        public EliteDbContext(DbContextOptions<TType> options):base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            if (string.IsNullOrEmpty(SchemaName))
                throw new ArgumentNullException(nameof(SchemaName), "Parameter '"+ nameof(SchemaName)+"' of '" +typeof(TType).Name+"' must be specified.");
        }
    }
}
