using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using demoDrozdov.Models;

namespace demoDrozdov.Context;

public partial class User11024Context : DbContext
{
    public User11024Context()
    {
    }

    public User11024Context(DbContextOptions<User11024Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnerProduct> PartnerProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=192.168.7.159;Database=user11024;Username=user11024;Password=89835");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("managers_pk");

            entity.ToTable("managers");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.IdRequest).HasColumnName("id_request");
            entity.Property(e => e.Managername)
                .HasColumnType("character varying")
                .HasColumnName("managername");
        });

        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("material_type_pk");

            entity.ToTable("material_type");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Materialtype1)
                .HasColumnType("character varying")
                .HasColumnName("materialtype");
            entity.Property(e => e.ScrapRate).HasColumnName("scrap_rate");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("partners_pk");

            entity.ToTable("partners");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Director)
                .HasColumnType("character varying")
                .HasColumnName("director");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.Historyproduct)
                .HasColumnType("character varying")
                .HasColumnName("historyproduct");
            entity.Property(e => e.Inn)
                .HasColumnType("character varying")
                .HasColumnName("inn");
            entity.Property(e => e.Logo)
                .HasColumnType("character varying")
                .HasColumnName("logo");
            entity.Property(e => e.Partneradress)
                .HasColumnType("character varying")
                .HasColumnName("partneradress");
            entity.Property(e => e.Partneremail)
                .HasColumnType("character varying")
                .HasColumnName("partneremail");
            entity.Property(e => e.Partnername)
                .HasColumnType("character varying")
                .HasColumnName("partnername");
            entity.Property(e => e.Partnerphone)
                .HasColumnType("character varying")
                .HasColumnName("partnerphone");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Salesplace)
                .HasColumnType("character varying")
                .HasColumnName("salesplace");
            entity.Property(e => e.Type)
                .HasColumnType("character varying")
                .HasColumnName("type");
        });

        modelBuilder.Entity<PartnerProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("partner_products_pk");

            entity.ToTable("partner_products");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Partnername).HasColumnName("partnername");
            entity.Property(e => e.Productamount).HasColumnName("productamount");
            entity.Property(e => e.Products).HasColumnName("products");
            entity.Property(e => e.Salesdate)
                .HasColumnType("character varying")
                .HasColumnName("salesdate");

            entity.HasOne(d => d.PartnernameNavigation).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.Partnername)
                .HasConstraintName("partner_products_partners_fk");

            entity.HasOne(d => d.ProductsNavigation).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.Products)
                .HasConstraintName("partner_products_products_fk");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pk");

            entity.ToTable("products");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Article)
                .HasColumnType("character varying")
                .HasColumnName("article");
            entity.Property(e => e.MinCostForpartners).HasColumnName("min_cost_forpartners");
            entity.Property(e => e.ProductName)
                .HasColumnType("character varying")
                .HasColumnName("product_name");
            entity.Property(e => e.ProductType).HasColumnName("product_type");

            entity.HasOne(d => d.ProductTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductType)
                .HasConstraintName("products_product_type_fk");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("product_type_pk");

            entity.ToTable("product_type");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.ProductTypeIndex).HasColumnName("product_type_index");
            entity.Property(e => e.Producttype1)
                .HasColumnType("character varying")
                .HasColumnName("producttype");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("requests");
        });
        modelBuilder.HasSequence("order point_id_seq").HasMax(2147483647L);
        modelBuilder.HasSequence("order_id_seq").HasMax(2147483647L);
        modelBuilder.HasSequence("order_seq");
        modelBuilder.HasSequence("product_id_seq").HasMax(2147483647L);
        modelBuilder.HasSequence("role_seq");
        modelBuilder.HasSequence("users_id_seq").HasMax(2147483647L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
