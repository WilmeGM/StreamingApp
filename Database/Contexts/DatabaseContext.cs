using ItlaTv.Core.Domain.Common;
using ItlaTv.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItlaTv.Infrastructure.Persistence.Contexts
{
    public class DatabaseContext : DbContext
    {
        //We pass the DbContext Configuration
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        //Databases tables
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Serie> Series { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {

            foreach(var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = "DefaultAppUser";
                        break;

                    case EntityState.Modified:
                        entry.Property(entity => entity.Created).IsModified = false;
                        entry.Property(entity => entity.CreatedBy).IsModified = false;


                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "DefaultAppUser";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tables
            modelBuilder.Entity<Producer>().ToTable("Producers");
            modelBuilder.Entity<Genre>().ToTable("Genres");
            modelBuilder.Entity<Serie>().ToTable("Series");
            #endregion

            #region Primary Keys
            modelBuilder.Entity<Producer>().HasKey(producer => producer.Id);
            modelBuilder.Entity<Genre>().HasKey(genre => genre.Id);
            modelBuilder.Entity<Serie>().HasKey(serie => serie.Id);
            #endregion

            #region Relationships

            #region producer-serie
            modelBuilder.Entity<Producer>()
                .HasMany<Serie>(producer => producer.Series)
                .WithOne(serie => serie.Producer)
                .HasForeignKey(serie => serie.ProducerId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region genre-serie
            modelBuilder.Entity<Genre>()
                .HasMany<Serie>(genre => genre.PrimarySeries)
                .WithOne(serie => serie.PrimaryGenre)
                .HasForeignKey(serie => serie.PrimaryGenreId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Genre>()
                .HasMany<Serie>(genre => genre.SecundarySeries)
                .WithOne(serie => serie.SecundaryGenre)
                .HasForeignKey(serie => serie.SecundaryGenreId)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            #endregion

            #region Property configurations

            #region Producer
            modelBuilder.Entity<Producer>()
                .Property(producer => producer.Name)
                .IsRequired();
            #endregion

            #region Genre
            modelBuilder.Entity<Genre>()
                .Property(genre => genre.Name)
                .IsRequired();
            #endregion

            #region Serie
            modelBuilder.Entity<Serie>()
                .Property(serie => serie.Name)
                .IsRequired();

            modelBuilder.Entity<Serie>()
                .Property(serie => serie.ImageUrl)
                .IsRequired();

            modelBuilder.Entity<Serie>()
                .Property(serie => serie.VideoUrl)
                .IsRequired();
            #endregion

            #endregion
        }
    }
}
