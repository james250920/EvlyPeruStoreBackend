using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace EvlyPeruStoreBK.Infrastructure.core.Data;

public partial class EvlyperuStoredbContext : DbContext
{
    public EvlyperuStoredbContext()
    {
    }

    public EvlyperuStoredbContext(DbContextOptions<EvlyperuStoredbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AttributeValues> AttributeValues { get; set; }

    public virtual DbSet<Attributes> Attributes { get; set; }

    public virtual DbSet<Business> Business { get; set; }

    public virtual DbSet<Businesscontacts> Businesscontacts { get; set; }

    public virtual DbSet<Countries> Countries { get; set; }

    public virtual DbSet<Districts> Districts { get; set; }

    public virtual DbSet<Naturalperson> Naturalperson { get; set; }

    public virtual DbSet<OrderItems> OrderItems { get; set; }

    public virtual DbSet<Orders> Orders { get; set; }

    public virtual DbSet<PaymentReceipts> PaymentReceipts { get; set; }

    public virtual DbSet<ProductCategories> ProductCategories { get; set; }

    public virtual DbSet<ProductVariants> ProductVariants { get; set; }

    public virtual DbSet<Products> Products { get; set; }

    public virtual DbSet<Provinces> Provinces { get; set; }

    public virtual DbSet<ReceiptTypes> ReceiptTypes { get; set; }

    public virtual DbSet<Typedocs> Typedocs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;uid=root;pwd=\"JamesFrank99=\";database=evlyperu_storedb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.0.1-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AttributeValues>(entity =>
        {
            entity.HasKey(e => e.ValueId).HasName("PRIMARY");

            entity.ToTable("attribute_values");

            entity.HasIndex(e => e.AttributeId, "attribute_id");

            entity.Property(e => e.ValueId).HasColumnName("value_id");
            entity.Property(e => e.AttributeId).HasColumnName("attribute_id");
            entity.Property(e => e.ValueName)
                .HasMaxLength(100)
                .HasColumnName("value_name");

            entity.HasOne(d => d.Attribute).WithMany(p => p.AttributeValues)
                .HasForeignKey(d => d.AttributeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("attribute_values_ibfk_1");
        });

        modelBuilder.Entity<Attributes>(entity =>
        {
            entity.HasKey(e => e.AttributeId).HasName("PRIMARY");

            entity.ToTable("attributes");

            entity.HasIndex(e => e.AttributeName, "attribute_name").IsUnique();

            entity.Property(e => e.AttributeId).HasColumnName("attribute_id");
            entity.Property(e => e.AttributeName)
                .HasMaxLength(100)
                .HasColumnName("attribute_name");
        });

        modelBuilder.Entity<Business>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("business");

            entity.HasIndex(e => e.Ruc, "RUC").IsUnique();

            entity.HasIndex(e => e.Cellphone, "cellphone").IsUnique();

            entity.HasIndex(e => e.Country, "country");

            entity.HasIndex(e => e.District, "district");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.Province, "province");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.Anniversary).HasColumnName("anniversary");
            entity.Property(e => e.Cellphone)
                .HasMaxLength(20)
                .HasColumnName("cellphone");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.District).HasColumnName("district");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.IsTax).HasColumnName("isTax");
            entity.Property(e => e.MerchName)
                .HasMaxLength(150)
                .HasColumnName("merchName");
            entity.Property(e => e.Province).HasColumnName("province");
            entity.Property(e => e.Ruc)
                .HasMaxLength(60)
                .HasColumnName("RUC");
            entity.Property(e => e.SocialReason)
                .HasMaxLength(150)
                .HasColumnName("socialReason");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.CountryNavigation).WithMany(p => p.Business)
                .HasForeignKey(d => d.Country)
                .HasConstraintName("business_ibfk_2");

            entity.HasOne(d => d.DistrictNavigation).WithMany(p => p.Business)
                .HasForeignKey(d => d.District)
                .HasConstraintName("business_ibfk_1");

            entity.HasOne(d => d.ProvinceNavigation).WithMany(p => p.Business)
                .HasForeignKey(d => d.Province)
                .HasConstraintName("business_ibfk_3");
        });

        modelBuilder.Entity<Businesscontacts>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("businesscontacts");

            entity.HasIndex(e => e.IdBusiness, "id_business");

            entity.HasIndex(e => e.IdNaturalperson, "id_naturalperson");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdBusiness).HasColumnName("id_business");
            entity.Property(e => e.IdNaturalperson).HasColumnName("id_naturalperson");

            entity.HasOne(d => d.IdBusinessNavigation).WithMany(p => p.Businesscontacts)
                .HasForeignKey(d => d.IdBusiness)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("businesscontacts_ibfk_2");

            entity.HasOne(d => d.IdNaturalpersonNavigation).WithMany(p => p.Businesscontacts)
                .HasForeignKey(d => d.IdNaturalperson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("businesscontacts_ibfk_1");
        });

        modelBuilder.Entity<Countries>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("countries");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Districts>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("districts");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.HasIndex(e => e.ProvinciaId, "provincia_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.ProvinciaId).HasColumnName("provincia_id");

            entity.HasOne(d => d.Provincia).WithMany(p => p.Districts)
                .HasForeignKey(d => d.ProvinciaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("districts_ibfk_1");
        });

        modelBuilder.Entity<Naturalperson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("naturalperson");

            entity.HasIndex(e => e.Cellphone, "cellphone").IsUnique();

            entity.HasIndex(e => e.Country, "country");

            entity.HasIndex(e => e.District, "district");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.NumDoc, "numDoc").IsUnique();

            entity.HasIndex(e => e.Province, "province");

            entity.HasIndex(e => e.TypeDoc, "typeDoc");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.Adminrole)
                .HasDefaultValueSql("'0'")
                .HasColumnName("adminrole");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.Cellphone)
                .HasMaxLength(20)
                .HasColumnName("cellphone");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.District).HasColumnName("district");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.NumDoc)
                .HasMaxLength(40)
                .HasColumnName("numDoc");
            entity.Property(e => e.Password)
                .HasMaxLength(45)
                .HasColumnName("password");
            entity.Property(e => e.Province).HasColumnName("province");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TypeDoc).HasColumnName("typeDoc");

            entity.HasOne(d => d.CountryNavigation).WithMany(p => p.Naturalperson)
                .HasForeignKey(d => d.Country)
                .HasConstraintName("naturalperson_ibfk_3");

            entity.HasOne(d => d.DistrictNavigation).WithMany(p => p.Naturalperson)
                .HasForeignKey(d => d.District)
                .HasConstraintName("naturalperson_ibfk_2");

            entity.HasOne(d => d.ProvinceNavigation).WithMany(p => p.Naturalperson)
                .HasForeignKey(d => d.Province)
                .HasConstraintName("naturalperson_ibfk_4");

            entity.HasOne(d => d.TypeDocNavigation).WithMany(p => p.Naturalperson)
                .HasForeignKey(d => d.TypeDoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("naturalperson_ibfk_1");
        });

        modelBuilder.Entity<OrderItems>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("PRIMARY");

            entity.ToTable("order_items");

            entity.HasIndex(e => e.OrderId, "order_id");

            entity.HasIndex(e => e.VariantId, "variant_id");

            entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("'1'")
                .HasColumnName("quantity");
            entity.Property(e => e.Subtotal)
                .HasPrecision(10, 2)
                .HasColumnName("subtotal");
            entity.Property(e => e.UnitPrice)
                .HasPrecision(10, 2)
                .HasColumnName("unit_price");
            entity.Property(e => e.VariantId).HasColumnName("variant_id");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_items_ibfk_1");

            entity.HasOne(d => d.Variant).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.VariantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("order_items_ibfk_2");
        });

        modelBuilder.Entity<Orders>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.ToTable("orders");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp")
                .HasColumnName("order_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(50)
                .HasColumnName("payment_method");
            entity.Property(e => e.ShippingAddress)
                .HasMaxLength(255)
                .HasColumnName("shipping_address");
            entity.Property(e => e.ShippingMethod)
                .HasMaxLength(50)
                .HasColumnName("shipping_method");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("'Pending'")
                .HasColumnName("status");
            entity.Property(e => e.TotalAmount)
                .HasPrecision(10, 2)
                .HasColumnName("total_amount");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<PaymentReceipts>(entity =>
        {
            entity.HasKey(e => e.ReceiptId).HasName("PRIMARY");

            entity.ToTable("payment_receipts");

            entity.HasIndex(e => e.OrderId, "order_id");

            entity.HasIndex(e => e.ReceiptNumber, "receipt_number").IsUnique();

            entity.HasIndex(e => e.ReceiptTypeId, "receipt_type_id");

            entity.Property(e => e.ReceiptId).HasColumnName("receipt_id");
            entity.Property(e => e.IssueDate).HasColumnName("issue_date");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ReceiptNumber)
                .HasMaxLength(50)
                .HasColumnName("receipt_number");
            entity.Property(e => e.ReceiptTypeId).HasColumnName("receipt_type_id");
            entity.Property(e => e.TaxAmount)
                .HasPrecision(10, 2)
                .HasColumnName("tax_amount");
            entity.Property(e => e.TotalAmount)
                .HasPrecision(10, 2)
                .HasColumnName("total_amount");

            entity.HasOne(d => d.Order).WithMany(p => p.PaymentReceipts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payment_receipts_ibfk_1");

            entity.HasOne(d => d.ReceiptType).WithMany(p => p.PaymentReceipts)
                .HasForeignKey(d => d.ReceiptTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payment_receipts_ibfk_2");
        });

        modelBuilder.Entity<ProductCategories>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("product_categories");

            entity.HasIndex(e => e.CategoryName, "category_name").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .HasColumnName("category_name");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
        });

        modelBuilder.Entity<ProductVariants>(entity =>
        {
            entity.HasKey(e => e.VariantId).HasName("PRIMARY");

            entity.ToTable("product_variants");

            entity.HasIndex(e => e.AttributeValueId, "attribute_value_id");

            entity.HasIndex(e => e.ProductId, "product_id");

            entity.HasIndex(e => e.Sku, "sku").IsUnique();

            entity.Property(e => e.VariantId).HasColumnName("variant_id");
            entity.Property(e => e.AdditionalPrice)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'")
                .HasColumnName("additional_price");
            entity.Property(e => e.AttributeValueId).HasColumnName("attribute_value_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Sku)
                .HasMaxLength(50)
                .HasColumnName("sku");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.AttributeValue).WithMany(p => p.ProductVariants)
                .HasForeignKey(d => d.AttributeValueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_variants_ibfk_2");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductVariants)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product_variants_ibfk_1");
        });

        modelBuilder.Entity<Products>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.CategoryId, "category_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("product_name");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_ibfk_1");
        });

        modelBuilder.Entity<Provinces>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("provinces");

            entity.HasIndex(e => e.CountryId, "country_id");

            entity.HasIndex(e => e.Nombre, "nombre").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountryId).HasColumnName("country_id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");

            entity.HasOne(d => d.Country).WithMany(p => p.Provinces)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("provinces_ibfk_1");
        });

        modelBuilder.Entity<ReceiptTypes>(entity =>
        {
            entity.HasKey(e => e.ReceiptTypeId).HasName("PRIMARY");

            entity.ToTable("receipt_types");

            entity.HasIndex(e => e.ReceiptTypeName, "receipt_type_name").IsUnique();

            entity.Property(e => e.ReceiptTypeId).HasColumnName("receipt_type_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ReceiptTypeName)
                .HasMaxLength(50)
                .HasColumnName("receipt_type_name");
        });

        modelBuilder.Entity<Typedocs>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("typedocs");

            entity.HasIndex(e => e.Name, "name").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(16)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
