using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Movies.Entities.Configurations
{
    public class movieConfigurations : IEntityTypeConfiguration<Model.MoviesEntity>
    {
        public void Configure(EntityTypeBuilder<Model.MoviesEntity> builder)
        {
            //Movies Entity'mde decimal olarak tanımladığım propertylerin detayını burda ayarladım.
            builder.Property(x => x.vote_average).HasPrecision(4, 1);
            builder.Property(x => x.runtime).HasPrecision(6,1);
        }
    }
}
