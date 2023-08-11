using AllMaterialsIn4Module.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AllMaterialsIn4Module.Configurations
{
    internal class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable(nameof(Genre)).HasKey(g => g.GenreId);
            builder.Property(g => g.GenreId).HasColumnName(nameof(Genre.GenreId)).IsRequired().HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(g => g.Title).HasColumnName(nameof(Genre.Title)).IsRequired().HasColumnType("nvarchar").HasMaxLength(70);
        }
    }
}
