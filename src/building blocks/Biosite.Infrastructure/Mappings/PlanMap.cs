using Biosite.Core.Constants;
using Biosite.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biosite.Infrastructure.Mappings
{
    public class PlanMap : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> entity)
        {

            //Entity
            entity.ToTable("homolog_biosite_plan");
            entity.HasKey(x => x.Id);

            //Properties
            entity.Property(x => x.Name).IsRequired().HasMaxLength(50).HasColumnType(Constants.Varchar);
            entity.Property(x => x.Description).IsRequired().HasMaxLength(150).HasColumnType(Constants.Varchar);
            entity.Property(x => x.LastUpdate).HasColumnType(Constants.Datetime);

            //Ignore equivalent NotMapping
            entity.Ignore(x => x.Notifications);

        }
    }
}
