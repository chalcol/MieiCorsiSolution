using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MieiCorsi.Models.Entities;

namespace MieiCorsi.Models.Services.Infrastructure
{
    public partial class MieiCorsiDbContext : DbContext
    {
        public MieiCorsiDbContext()
        {
        }

        public MieiCorsiDbContext(DbContextOptions<MieiCorsiDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Corsi> Corsi { get; set; }
        public virtual DbSet<Lessons> Lessons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MieiCorsiDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

           
            modelBuilder.Entity<Corsi>(entity =>
            {
                entity.ToTable("Corsi");//Superfluo se la tabella si chiama come la proprieta che esponne il Dbset: "Corsi"
                entity.Property(e => e.Id).HasColumnName("id");
                entity.HasKey(corso => corso.Id); // Superfluo se la proprieta si chiama "Id" o "CorsiId"

                //Mapping per gli Owned Types
                entity.OwnsOne(corso => corso.CurrentPrice
                
                , builder =>
                  {
                      builder.Property(money => money.Currency).HasColumnName("CurrentPrice_Currency")//Superfluo perché Stiamo rispettando la convenzione dei nomi
                      .HasConversion<String>();
                      builder.Property(money => money.Amount).HasColumnName("CurrentPrice_Amount");//Superfluo perché Stiamo rispettando la convenzione dei nomi
                  });

                entity.OwnsOne(corso => corso.FullPrice, builder =>
                {
                    builder.Property(money => money.Currency).HasConversion<String>();
                });
                // Mapping per le relazioni
                entity.HasMany(course => course.Lessons)
                .WithOne(lesson => lesson.Corsi)
                .HasForeignKey(lesson => lesson.CorsiId);//superflua se la proprietà si chiama CorsiId

                #region Mapping generato automaticamente daltool di reverse ingeneering
                //    entity.Property(e => e.Id).HasColumnName("id");

                //    entity.Property(e => e.Author)
                //        .IsRequired()
                //        .HasMaxLength(100);

                //    entity.Property(e => e.CurrentPriceAmount)
                //        .HasColumnName("CurrentPrice_Amount")
                //        .HasColumnType("numeric(18, 0)")
                //        .HasDefaultValueSql("((0))");

                //    entity.Property(e => e.CurrentPriceCurrency)
                //        .HasColumnName("CurrentPrice_Currency")
                //        .HasMaxLength(3)
                //        .HasDefaultValueSql("('EUR')");

                //    entity.Property(e => e.Email)
                //        .IsRequired()
                //        .HasMaxLength(100)
                //        .HasDefaultValueSql("('EUR')");

                //    entity.Property(e => e.FullPriceAmount)
                //        .HasColumnName("FullPrice_Amount")
                //        .HasColumnType("numeric(18, 0)")
                //        .HasDefaultValueSql("((0))");

                //    entity.Property(e => e.FullPriceCurrency)
                //        .HasColumnName("FullPrice_Currency")
                //        .HasMaxLength(3);

                //    entity.Property(e => e.ImagePath).HasMaxLength(100);

                //    entity.Property(e => e.Rating).HasDefaultValueSql("((0))");

                //    entity.Property(e => e.Title)
                //        .IsRequired()
                //        .HasMaxLength(100);

                #endregion
            });




            modelBuilder.Entity<Lessons>(entity =>
            {
              
                #region Mapping generato automaticamente daltool di reverse ingeneering
                //    entity.Property(e => e.Duration)
                //        .IsRequired()
                //        .HasMaxLength(8)
                //        .HasDefaultValueSql("('00:00:00')");

                //    entity.Property(e => e.Title)
                //        .IsRequired()
                //        .HasColumnName("Title ")
                //        .HasMaxLength(100);

                //    entity.HasOne(d => d.Corsi)
                //        .WithMany(p => p.Lessons)
                //        .HasForeignKey(d => d.CorsiId)
                //        .HasConstraintName("FK__Lessons__CorsiId__3F466844");
                #endregion
            });
            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
