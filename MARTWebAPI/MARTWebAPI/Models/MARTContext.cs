using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MARTWebAPI.Models
{
    public partial class MARTContext : DbContext
    {
        public MARTContext()
        {
        }

        public MARTContext(DbContextOptions<MARTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Carts> Carts { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=10.3.117.39;Database=MART;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carts>(entity =>
            {
                entity.ToTable("carts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Brandname)
                    .HasColumnName("brandname")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__carts__productId__52593CB8");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__carts__userId__5165187F");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.Emailadress)
                    .HasName("UQ__orders__FAD47ACBDACA55FA")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Emailadress)
                    .HasColumnName("emailadress")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobilenumber).HasColumnName("mobilenumber");

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("totalPrice")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__orders__userId__34C8D9D1");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("products");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Brandname)
                    .HasColumnName("brandname")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SellerId).HasColumnName("sellerId");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SellerId)
                    .HasConstraintName("FK__products__seller__4E88ABD4");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.ToTable("seller");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Emailadress)
                    .HasColumnName("emailadress")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mobilenumber).HasColumnName("mobilenumber");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sname)
                    .HasColumnName("sname")
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("users");

                entity.HasIndex(e => e.Emailadress)
                    .HasName("UQ__users__FAD47ACBDB53A2B9")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Emailadress)
                    .HasColumnName("emailadress")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Mobilenumber).HasColumnName("mobilenumber");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
