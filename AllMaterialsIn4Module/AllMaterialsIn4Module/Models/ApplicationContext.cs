using AllMaterialsIn4Module.Configurations;
using AllMaterialsIn4Module.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AllMaterialsIn4Module.Models
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<ArtistSong> ArtistSongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new SongConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistSongConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();

            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());

            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");

            // создаем конфигурацию
            var config = builder.Build();

            // получаем строку подключения
            string? connectionString = config.GetConnectionString("ConnectionString_First");

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(connectionString);
        }
    }
}
