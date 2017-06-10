using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShoppingCart.Models
{
    public partial class ShoppingCartContext : DbContext
    {

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<ConectionUsers> ConectionUsers { get; set; }
        public virtual DbSet<ProductShoppingCarts> ProductShoppingCarts { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ShoppingCarts> ShoppingCarts { get; set; }

        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options)
            : base(options)
        {
        }

        public ShoppingCartContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            //optionsBuilder.UseSqlServer(@"Server=.;Database=ShoppingCart;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserIdClaims");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserIdLogins");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserIdRoles");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.ShoppingCartId)
                    .HasName("IX_ShoppingCartId");

                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Amaterno)
                    .HasColumnName("AMaterno")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Apaterno)
                    .HasColumnName("APaterno")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Direccion).HasColumnType("varchar(170)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.Nombres).HasColumnType("varchar(150)");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.HasOne(d => d.ShoppingCart)
                    .WithMany(p => p.AspNetUsers)
                    .HasForeignKey(d => d.ShoppingCartId)
                    .HasConstraintName("FK_dbo.AspNetUsers_dbo.ShoppingCarts_ShoppingCartId");
            });

            modelBuilder.Entity<ConectionUsers>(entity =>
            {
                entity.HasKey(e => e.ConectionUserId)
                    .HasName("PK_dbo.ConectionUsers");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserIdConnectionUsers");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ConectionUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.ConectionUsers_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<ProductShoppingCarts>(entity =>
            {
                entity.HasKey(e => new { e.ProductProductId, e.ShoppingCartShoppingCartId })
                    .HasName("PK_dbo.ProductShoppingCarts");

                entity.HasIndex(e => e.ProductProductId)
                    .HasName("IX_Product_ProductId");

                entity.HasIndex(e => e.ShoppingCartShoppingCartId)
                    .HasName("IX_ShoppingCart_ShoppingCartId");

                entity.Property(e => e.ProductProductId).HasColumnName("Product_ProductId");

                entity.Property(e => e.ShoppingCartShoppingCartId).HasColumnName("ShoppingCart_ShoppingCartId");

                entity.HasOne(d => d.ProductProduct)
                    .WithMany(p => p.ProductShoppingCarts)
                    .HasForeignKey(d => d.ProductProductId)
                    .HasConstraintName("FK_dbo.ProductShoppingCarts_dbo.Products_Product_ProductId");

                entity.HasOne(d => d.ShoppingCartShoppingCart)
                    .WithMany(p => p.ProductShoppingCarts)
                    .HasForeignKey(d => d.ShoppingCartShoppingCartId)
                    .HasConstraintName("FK_dbo.ProductShoppingCarts_dbo.ShoppingCarts_ShoppingCart_ShoppingCartId");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK_dbo.Products");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.Precio).HasColumnType("money");
            });

            modelBuilder.Entity<ShoppingCarts>(entity =>
            {
                entity.HasKey(e => e.ShoppingCartId)
                    .HasName("PK_dbo.ShoppingCarts");

                entity.Property(e => e.ClientGuid)
                    .IsRequired()
                    .HasColumnName("ClientGUID")
                    .HasColumnType("varchar(40)");
            });
        }
    }
}