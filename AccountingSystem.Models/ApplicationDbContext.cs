using AccountingSystem.Models.DB;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountingSystem.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //  Database.EnsureCreated();
        }
        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<CommoditiesBuyers> CommoditiesBuyers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Commodity> Commodities { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Provider> Providers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            // Explicitly setting PK:
            builder.Entity<Buyer>().HasKey(i => i.Id);
            builder.Entity<Buyer>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            builder.Entity<Company>().HasKey(i => i.Id);
            builder.Entity<Company>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            builder.Entity<Provider>().HasKey(i => i.Id);
            builder.Entity<Provider>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            builder.Entity<Commodity>().HasKey(i => i.Id);
            builder.Entity<Commodity>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            builder.Entity<ContactInfo>().HasKey(i => i.Id);
            builder.Entity<ContactInfo>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            #region FK

            builder.Entity<ApplicationUser>()
                .HasOne(m => m.Provider)
                .WithOne(m => m.User)
                .HasForeignKey<Provider>(m => m.UserId);
               // .OnDelete(DeleteBehavior.Cascade); //need ?

            builder.Entity<ApplicationUser>()
              .HasMany(m => m.Company)
              .WithOne(m => m.User)
              .HasForeignKey(m => m.UserId);
              //.OnDelete(DeleteBehavior.Cascade); 

            builder.Entity<Company>()
                .HasMany(o => o.Commodities)
                .WithOne(m => m.Company)
                .HasForeignKey(m => m.CompanyId)
                .OnDelete(DeleteBehavior.Cascade); //need ?

            builder.Entity<ApplicationUser>()
                .HasOne(b => b.Buyer)
                .WithOne(b => b.User)
                .HasForeignKey<Buyer>(b => b.UserId);
                //   .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Company>()
                .HasMany(o => o.Providers)
                .WithOne(m => m.Company)
                .HasForeignKey(m => m.CompanyId);

            builder.Entity<Company>()
                .HasOne(c => c.ContactInfo)
                .WithOne(c => c.Company)
                .HasForeignKey<ContactInfo>(m => m.CompanyId);

            builder.Entity<Buyer>()
                .HasOne(c => c.ContactInfo)
                .WithOne(c => c.Buyer)
                .HasForeignKey<ContactInfo>(m => m.BuyerId);
            #endregion
            // Configuring Many-To-Many relationship  and compound index
            #region Many-To-Many 

            builder.Entity<Commodity>()
                .HasMany(bc => bc.CommoditiesBuyerses)
                .WithOne(c => c.Commodity)
                .HasForeignKey(bc => bc.CommodityId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Buyer>()
                .HasMany(bc => bc.CommoditiesBuyerses)
                .WithOne(b => b.Buyer)
                .HasForeignKey(bc => bc.BuyerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CommoditiesBuyers>().HasKey(cb => new { cb.BuyerId, cb.CommodityId });

            #endregion

            builder.Entity<CommoditiesBuyers>()
                .Property(c => c.Amount)
                .IsRequired();

            builder.Entity<ContactInfo>()
                .Property(c => c.AddressLine)
                .IsRequired();

            builder.Entity<ContactInfo>()
                .Property(c => c.PostalCode)
                .IsRequired();

            builder.Entity<ContactInfo>()
                .Property(c => c.IsCompany)
                .IsRequired();

            builder.Entity<ContactInfo>()
                .Property(c => c.Name)
                .IsRequired();

            builder.Entity<ContactInfo>()
                .Property(c => c.Phone)
                .IsRequired();

            builder.Entity<ContactInfo>()
                .Property(c => c.CompanyId)
                .IsRequired(false);

            builder.Entity<ContactInfo>()
                .Property(c => c.BuyerId)
                .IsRequired(false);



            builder.Entity<Company>()
                .HasIndex(o => o.NameCompany)
                .IsUnique();
            //NameCompany  IsUnique -?


            builder.Entity<Commodity>()
                .Property(c => c.Amount)
                .IsRequired();

            builder.Entity<Commodity>()
                .Property(c => c.MinAmount)
                .IsRequired();


            builder.Entity<Commodity>()
                .Property(c => c.Name)
                .IsRequired();

            builder.Entity<Commodity>()
                .Property(c => c.Place)
                .IsRequired();

            builder.Entity<Commodity>()
                .Property(c => c.TypeCommodity)
                .IsRequired();

            builder.Entity<Commodity>()
                .Property(c => c.Description)
                .IsRequired(false);





        }
    }
}
