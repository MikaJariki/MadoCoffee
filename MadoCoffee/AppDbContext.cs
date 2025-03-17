using MadoCoffee.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MadoCoffee
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<SupplierIngredientMapping> SupplierIngredientMappings { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDishMapping> OrderDishMappings { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<DishMenuMapping> DishMenuMappings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<EmployeeShiftMapping> EmployeeShiftMappings { get; set; }
        public DbSet<Bill> Bills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(GetConnectionString());
            }
        }

        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
            var strConn = config["ConnectionStrings:ConnectedDb"];

            return strConn;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .HasOne(b => b.Customer)
                .WithMany(c => c.Bills)
                .HasForeignKey(b => b.CustomerID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DishMenuMapping>()
                .HasKey(dm => new { dm.DishID, dm.MenuID });
            modelBuilder.Entity<OrderDishMapping>()
                .HasKey(od => new { od.OrderID, od.DishID });
            modelBuilder.Entity<EmployeeShiftMapping>()
                .HasKey(es => new { es.ShiftID, es.EmpID });
            modelBuilder.Entity<SupplierIngredientMapping>()
                .HasKey(si => new { si.SupID, si.IngID, si.TransactionDate });

            modelBuilder.Entity<SupplierIngredientMapping>()
                .HasOne(si => si.Supplier)
                .WithMany(s => s.SupplierIngredientMappings)
                .HasForeignKey(si => si.SupID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SupplierIngredientMapping>()
                .HasOne(si => si.Ingredient)
                .WithMany(i => i.SupplierIngredientMappings)
                .HasForeignKey(si => si.IngID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasOne(o => o.Customer)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(o => o.CustomerID)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(o => o.CreatedByEmployee)
                    .WithMany()
                    .HasForeignKey(o => o.CreatedBy)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(o => o.UpdatedByEmployee)
                    .WithMany()
                    .HasForeignKey(o => o.UpdatedBy)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(o => o.Bill)
                    .WithMany(b => b.Orders)  
                    .HasForeignKey(o => o.BillID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(o => o.Table)
                    .WithMany(t => t.Orders)
                    .HasForeignKey(o => o.TableID)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Ingredient>() 
                    .HasOne(i => i.Unit)
                    .WithMany(u => u.Ingredients)
                    .HasForeignKey(i => i.UnitID)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                    .HasOne(e => e.Role)
                    .WithMany(r => r.Employees)
                    .HasForeignKey(e => e.RoleID)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
