using Database.Models;
using Microsoft.EntityFrameworkCore;


namespace Database
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Series> Series { get; set; } //ESTO ES COMO LA TABLA PRODUCTO QUE ESTA EN LA BASE DE DATOS, SI  YO TUVIERA UNA TABLA TV EN MI SQL, AHI FUERA TV

        public DbSet<Productora> Productoras { get; set; }

        public DbSet<Generos> Generos { get; set; } //ESTO ES COMO LA TABLA PRODUCTO QUE ESTA EN LA BASE DE DATOS, SI  YO TUVIERA UNA TABLA TV EN MI SQL, AHI FUERA TV
        public DbSet<SeriesGeneros> SeriesGeneros { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            #region tables

            modelBuilder.Entity<Series>().ToTable("Series");
            modelBuilder.Entity<Productora>().ToTable("Productoras");
            modelBuilder.Entity<Generos>().ToTable("Generos");
            modelBuilder.Entity<SeriesGeneros>().ToTable("SeriesGeneros");



            #endregion

            #region "primary keys"

            modelBuilder.Entity<Series>().HasKey(Series => Series.SerieId);
            modelBuilder.Entity<Productora>().HasKey(productora => productora.ProductoraId);
            modelBuilder.Entity<Generos>().HasKey(Genero => Genero.GeneroId);
            modelBuilder.Entity<SeriesGeneros>().HasKey(sg => new { sg.SerieId, sg.GeneroId });

            #endregion

            #region relationships
            modelBuilder.Entity<Productora>()
               .HasMany<Series>(s => s.SerieProducturaLista)
               .WithOne(s => s.Productora)
               .HasForeignKey(s => s.ProductoraId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SeriesGeneros>()
                .HasOne(sg => sg.Series)
                .WithMany(s => s.SeriesGeneroLista)
                .HasForeignKey(sg => sg.SerieId);


            modelBuilder.Entity<SeriesGeneros>()
                .HasOne(sg => sg.Genero)
                .WithMany(g => g.SeriesGenerosLista)
                .HasForeignKey(sg => sg.GeneroId);


            #endregion



            #region "property configuration"

            #region Series

            modelBuilder.Entity<Series>()
                .Property(s => s.Nombre)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Series>()
                .Property(s => s.Portada)
                .IsRequired()
                .HasColumnType("varchar(max)");

            modelBuilder.Entity<Series>()
                .Property(s => s.Enlaces)
                .IsRequired();



            #endregion

            #region Productora

            modelBuilder.Entity<Productora>()
                .Property(p => p.Nombre)
                .IsRequired()
                .HasMaxLength(150);

            #endregion

            #region Genero

            modelBuilder.Entity<Generos>()
                .Property(g => g.Nombre)
                .IsRequired()
                .HasMaxLength(150);

            #endregion

            #endregion
        }
    }
}
