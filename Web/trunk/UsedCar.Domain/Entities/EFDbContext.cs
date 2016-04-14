using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsedCar.Domain
{
    public class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("name=EFDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            // 移除EF的表名(复数)公约
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<SysUser> SysUsers { set; get; }
        public DbSet<SysModule> SysModules { set; get; }
        public DbSet<SysAction> SysActions { set; get; }
        public DbSet<SysRole> SysRoles { set; get; }

        public DbSet<RoleAction> RoleActions { set; get; }
        public DbSet<UserRole> UserRoles { set; get; }

        public DbSet<Car> Cars { set; get; }
        public DbSet<BasicParm> BasicParms { set; get; }
        public DbSet<EngineParm> EngineParms { set; get; }
        public DbSet<Chassis> Chassises { set; get; }
        public DbSet<Security> Securities { set; get; }
        public DbSet<External> Externals { set; get; }
        public DbSet<Internal> Internals { set; get; }
    }
}
