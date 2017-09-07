using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiMoho.Models
{
    public partial class ApiMohoContext : DbContext
    {
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<CitySeleectionTable> CitySeleectionTable { get; set; }
        public virtual DbSet<CountrySelectionTable> CountrySelectionTable { get; set; }
        public virtual DbSet<ListingSelectionTable> ListingSelectionTable { get; set; }
        public virtual DbSet<ProvinceSelectionTable> ProvinceSelectionTable { get; set; }
        public virtual DbSet<UserListings> UserListings { get; set; }
        public virtual DbSet<UserReview> UserReview { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=108.59.84.13; Database=ApiMoho; Trusted_Connection=False; User Id=sa;Password=Xa/&b.\)X.BEi&3;");
//                optionsBuilder.UseSqlServer(@"data source=.\SQLEXPRESS;initial catalog=ApiMoho;persist security info=True;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.IsPremium).HasDefaultValueSql("((0))");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UpVote).HasDefaultValueSql("((0))");

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<CitySeleectionTable>(entity =>
            {
                entity.Property(e => e.RegionName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.CountryRef)
                    .WithMany(p => p.CitySeleectionTable)
                    .HasForeignKey(d => d.CountryRefId)
                    .HasConstraintName("FK_CityCountryRefId");

                entity.HasOne(d => d.ProvinceRef)
                    .WithMany(p => p.CitySeleectionTable)
                    .HasForeignKey(d => d.ProvinceRefId)
                    .HasConstraintName("FK_CityProvinceRefId");
            });

            modelBuilder.Entity<CountrySelectionTable>(entity =>
            {
                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ListingSelectionTable>(entity =>
            {
                entity.Property(e => e.ListingName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProvinceSelectionTable>(entity =>
            {
                entity.Property(e => e.ProvinceName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.CountryRef)
                    .WithMany(p => p.ProvinceSelectionTable)
                    .HasForeignKey(d => d.CountryRefId)
                    .HasConstraintName("FK_ProvinceCountryRefId");
            });

            modelBuilder.Entity<UserListings>(entity =>
            {
                entity.HasKey(e => e.UserListingId);

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.ListingDate).HasColumnType("datetime");

                entity.Property(e => e.ListingDescription)
                    .HasMaxLength(450)
                    .IsUnicode(false);

                entity.Property(e => e.ListingEnabled).HasDefaultValueSql("((1))");

                entity.Property(e => e.ListingName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ListingTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.UserListings)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_OwnerId");
            });

            modelBuilder.Entity<UserReview>(entity =>
            {
                entity.Property(e => e.ReviewDate).HasColumnType("datetime");

                entity.Property(e => e.ReviewDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.ReviewDescription).IsUnicode(false);

                entity.Property(e => e.ReviewOwnerRefId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.ReviewTitle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReviewUsername)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UpVoteNum)
                    .IsRequired()
                    .HasColumnType("nchar(10)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.UserRefId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.ReviewOwnerRef)
                    .WithMany(p => p.UserReviewReviewOwnerRef)
                    .HasForeignKey(d => d.ReviewOwnerRefId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewOwnerId");

                entity.HasOne(d => d.UserRef)
                    .WithMany(p => p.UserReviewUserRef)
                    .HasForeignKey(d => d.UserRefId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReviewUserRefId");
            });
        }
    }
}
