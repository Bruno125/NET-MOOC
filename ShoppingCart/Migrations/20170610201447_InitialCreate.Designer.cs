using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ShoppingCart.Models;

namespace ShoppingCart.Migrations
{
    [DbContext(typeof(ShoppingCartContext))]
    [Migration("20170610201447_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ShoppingCart.Models.AspNetRoles", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("ShoppingCart.Models.AspNetUserClaims", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .HasName("IX_UserIdClaims");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("ShoppingCart.Models.AspNetUserLogins", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("UserId")
                        .HasMaxLength(128);

                    b.HasKey("LoginProvider", "ProviderKey", "UserId")
                        .HasName("PK_dbo.AspNetUserLogins");

                    b.HasIndex("UserId")
                        .HasName("IX_UserIdLogins");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("ShoppingCart.Models.AspNetUserRoles", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(128);

                    b.Property<string>("RoleId")
                        .HasMaxLength(128);

                    b.HasKey("UserId", "RoleId")
                        .HasName("PK_dbo.AspNetUserRoles");

                    b.HasIndex("RoleId")
                        .HasName("IX_RoleId");

                    b.HasIndex("UserId")
                        .HasName("IX_UserIdRoles");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("ShoppingCart.Models.AspNetUsers", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(128);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Amaterno")
                        .HasColumnName("AMaterno")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Apaterno")
                        .HasColumnName("APaterno")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Direccion")
                        .HasColumnType("varchar(170)");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTime?>("LockoutEndDateUtc")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombres")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int?>("ShoppingCartId");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("ShoppingCartId")
                        .HasName("IX_ShoppingCartId");

                    b.HasIndex("UserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ShoppingCart.Models.ConectionUsers", b =>
                {
                    b.Property<int>("ConectionUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConectionId");

                    b.Property<string>("UserId")
                        .HasMaxLength(128);

                    b.HasKey("ConectionUserId")
                        .HasName("PK_dbo.ConectionUsers");

                    b.HasIndex("UserId")
                        .HasName("IX_UserIdConnectionUsers");

                    b.ToTable("ConectionUsers");
                });

            modelBuilder.Entity("ShoppingCart.Models.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("money");

                    b.HasKey("ProductId")
                        .HasName("PK_dbo.Products");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ShoppingCart.Models.ProductShoppingCarts", b =>
                {
                    b.Property<int>("ProductProductId")
                        .HasColumnName("Product_ProductId");

                    b.Property<int>("ShoppingCartShoppingCartId")
                        .HasColumnName("ShoppingCart_ShoppingCartId");

                    b.HasKey("ProductProductId", "ShoppingCartShoppingCartId")
                        .HasName("PK_dbo.ProductShoppingCarts");

                    b.HasIndex("ProductProductId")
                        .HasName("IX_Product_ProductId");

                    b.HasIndex("ShoppingCartShoppingCartId")
                        .HasName("IX_ShoppingCart_ShoppingCartId");

                    b.ToTable("ProductShoppingCarts");
                });

            modelBuilder.Entity("ShoppingCart.Models.ShoppingCarts", b =>
                {
                    b.Property<int>("ShoppingCartId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientGuid")
                        .IsRequired()
                        .HasColumnName("ClientGUID")
                        .HasColumnType("varchar(40)");

                    b.HasKey("ShoppingCartId")
                        .HasName("PK_dbo.ShoppingCarts");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("ShoppingCart.Models.AspNetUserClaims", b =>
                {
                    b.HasOne("ShoppingCart.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserClaims")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShoppingCart.Models.AspNetUserLogins", b =>
                {
                    b.HasOne("ShoppingCart.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserLogins")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShoppingCart.Models.AspNetUserRoles", b =>
                {
                    b.HasOne("ShoppingCart.Models.AspNetRoles", "Role")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShoppingCart.Models.AspNetUsers", "User")
                        .WithMany("AspNetUserRoles")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShoppingCart.Models.AspNetUsers", b =>
                {
                    b.HasOne("ShoppingCart.Models.ShoppingCarts", "ShoppingCart")
                        .WithMany("AspNetUsers")
                        .HasForeignKey("ShoppingCartId");
                });

            modelBuilder.Entity("ShoppingCart.Models.ConectionUsers", b =>
                {
                    b.HasOne("ShoppingCart.Models.AspNetUsers", "User")
                        .WithMany("ConectionUsers")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.ConectionUsers_dbo.AspNetUsers_UserId");
                });

            modelBuilder.Entity("ShoppingCart.Models.ProductShoppingCarts", b =>
                {
                    b.HasOne("ShoppingCart.Models.Products", "ProductProduct")
                        .WithMany("ProductShoppingCarts")
                        .HasForeignKey("ProductProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShoppingCart.Models.ShoppingCarts", "ShoppingCartShoppingCart")
                        .WithMany("ProductShoppingCarts")
                        .HasForeignKey("ShoppingCartShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
