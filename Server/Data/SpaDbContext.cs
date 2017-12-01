using AspCoreServer.Models;
using Microsoft.EntityFrameworkCore;

namespace AspCoreServer.Data
{
    public class SpaDbContext : DbContext
    {
        public SpaDbContext(DbContextOptions<SpaDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        //List of DB Models - Add your DB models here

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        public DbSet<User> User { get; set; }

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        /// <value>The service.</value>
        public DbSet<Service> Service { get; set; }
    }
}
