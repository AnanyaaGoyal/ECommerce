using AP.Common;
using Microsoft.EntityFrameworkCore;

namespace AP.Entities.DataModels;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<OrderDetails> OrderDetails { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => new { e.CartId, e.ProductId });

            entity.ToTable("Cart");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Cart__ProductId__2C3393D0");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CDD542D1B0");

            entity.Property(e => e.Mfd).HasColumnType("datetime");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07732AD692");

            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MobileNo).HasMaxLength(10);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasData(new Users
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin",
                Username = "iamademo.12@gmail.com",
                Password = EncryptPassword.EncryptPass("Admin@123"),
                Gender = GlobalEnum.Gender.Female.ToString(),
                BirthDate = DateTime.Now,
                MobileNo = "0000000000",
                Role = GlobalEnum.Role.Admin.ToString(),
                CreatedAt = DateTime.Now,
                CreatedBy = 1,
                UpdatedAt = null,
                UpdatedBy = null,
            });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
