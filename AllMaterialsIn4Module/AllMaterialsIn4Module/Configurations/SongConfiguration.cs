using AllMaterialsIn4Module.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllMaterialsIn4Module.Configurations
{
    internal class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable(nameof(Song)).HasKey(e => e.SongId);
            builder.Property(e => e.SongId).HasColumnName(nameof(Song.SongId)).IsRequired().HasColumnType("integer").ValueGeneratedOnAdd();
            builder.Property(e => e.Title).HasColumnName(nameof(Song.Title)).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(e => e.Duration).HasColumnName(nameof(Song.Duration)).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            builder.Property(e => e.ReleasedDate).HasColumnName(nameof(Song.ReleasedDate)).IsRequired().HasColumnType("datetime").HasMaxLength(7);
        }
    }
}
