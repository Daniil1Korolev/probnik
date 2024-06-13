using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fishing2._0
{
    public class UchetContext : DbContext
    {
        public UchetContext() : base("ribalkaEntities") { }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.ID_User);

            base.OnModelCreating(modelBuilder);
        }
    }
}