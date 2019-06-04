using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaBox.Data
{
    public partial class PizzaBoxDbContext : DbContext
    {
        public PizzaBoxDbContext()
        {
        }

        public PizzaBoxDbContext(DbContextOptions<PizzaBoxDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Entities.Address> Addresses { get; set; }
        public virtual DbSet<Entities.Feature> Features { get; set; }
        public virtual DbSet<Entities.Item> Items { get; set; }
        public virtual DbSet<Entities.Order> Orders { get; set; }
        public virtual DbSet<Entities.Outlet> Outlets { get; set; }
        public virtual DbSet<Entities.PeopleEmployee> PeopleEmployees { get; set; }
        public virtual DbSet<Entities.Person> People { get; set; }
        public virtual DbSet<Entities.StateTax> StateTaxes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=model;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Entities.Address>(entity =>
            {
                entity.HasIndex(e => e.OutletId)
                    .HasName("IX_FK_OutletAddress");

                entity.HasIndex(e => e.PersonId)
                    .HasName("IX_FK_PersonAddress");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Outlet)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.OutletId)
                    .HasConstraintName("FK_OutletAddress");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_PersonAddress");
            });

            modelBuilder.Entity<Entities.Feature>(entity =>
            {
                entity.HasIndex(e => e.OutletId)
                    .HasName("IX_FK_OutletFeature");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Outlet)
                    .WithMany(p => p.Features)
                    .HasForeignKey(d => d.OutletId)
                    .HasConstraintName("FK_OutletFeature");
            });

            modelBuilder.Entity<Entities.Item>(entity =>
            {
                entity.HasIndex(e => e.OutletId)
                    .HasName("IX_FK_OutletItem");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Outlet)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.OutletId)
                    .HasConstraintName("FK_OutletItem");
            });

            modelBuilder.Entity<Entities.Order>(entity =>
            {
                entity.HasIndex(e => e.OutletId)
                    .HasName("IX_FK_OutletOrder");

                entity.HasIndex(e => e.PersonId)
                    .HasName("IX_FK_PersonOrder");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Outlet)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OutletId)
                    .HasConstraintName("FK_OutletOrder");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PersonId)
                    .HasConstraintName("FK_PersonOrder");
            });

            modelBuilder.Entity<Entities.Outlet>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Entities.PeopleEmployee>(entity =>
            {
                entity.HasIndex(e => e.OutletId)
                    .HasName("IX_FK_OutletEmployee");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.PeopleEmployee)
                    .HasForeignKey<Entities.PeopleEmployee>(d => d.Id)
                    .HasConstraintName("FK_Employee_inherits_Person");

                entity.HasOne(d => d.Outlet)
                    .WithMany(p => p.PeopleEmployees)
                    .HasForeignKey(d => d.OutletId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OutletEmployee");
            });

            modelBuilder.Entity<Entities.Person>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Entities.StateTax>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}