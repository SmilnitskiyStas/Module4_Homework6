using AllMaterialsIn4Module.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllMaterialsIn4Module.Configurations
{
    internal class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable(nameof(Artist)).HasKey(a => a.ArtistId);
            builder.Property(a => a.ArtistId).HasColumnName(nameof(Artist.ArtistId)).IsRequired().HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(a => a.Name).HasColumnName(nameof(Artist.Name)).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(a => a.DateOfBirth).HasColumnName(nameof(Artist.DateOfBirth)).IsRequired().HasColumnType("datetime").HasMaxLength(7);
            builder.Property(a => a.Phone).HasColumnName(nameof(Artist.Phone)).IsRequired(false).HasColumnType("nvarchar").HasMaxLength(20);
            builder.Property(a => a.Email).HasColumnName(nameof(Artist.Email)).IsRequired(false).HasColumnType("nvarchar").HasMaxLength(50);
            builder.Property(a => a.InstagramUrl).HasColumnName(nameof(Artist.InstagramUrl)).IsRequired(false).HasColumnType("nvarchar").HasMaxLength(255);
        }
    }
}
