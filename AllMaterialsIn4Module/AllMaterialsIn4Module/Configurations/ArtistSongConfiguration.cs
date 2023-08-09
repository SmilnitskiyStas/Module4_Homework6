using AllMaterialsIn4Module.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllMaterialsIn4Module.Configurations
{
    internal class ArtistSongConfiguration : IEntityTypeConfiguration<ArtistSong>
    {
        public void Configure(EntityTypeBuilder<ArtistSong> builder)
        {
            builder.ToTable(nameof(ArtistSong)).HasKey(a => a.ArtistSongId);
            builder.Property(a => a.ArtistSongId).HasColumnName(nameof(ArtistSong.ArtistSongId)).IsRequired().HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(a => a.ArtistId).HasColumnName(nameof(ArtistSong.ArtistId)).IsRequired().HasColumnType("int");
            builder.Property(a => a.SongId).HasColumnName(nameof(ArtistSong.SongId)).IsRequired().HasColumnType("int");
        }
    }
}
