using Biosite.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Biosite.Infrastructure.Mappings
{
    public class PlanAreaMap : IEntityTypeConfiguration<PlanArea>
    {
        public void Configure(EntityTypeBuilder<PlanArea> entity)
        {
            //Entity
            entity.ToTable("homolog_biosite_plan_area");
            entity.HasKey(x => new { x.PlanId, x.AreaId });

            //Properties

            //Ignore equivalent NotMapping
            entity.Ignore(x => x.Notifications);

            //Relationchip cardinality
            entity
                .HasOne(am => am.Plan)
                .WithMany(a => a.PlanAreas)
                .HasForeignKey(am => am.PlanId);

            entity
                .HasOne(am => am.Area)
                .WithMany(a => a.PlanAreas)
                .HasForeignKey(am => am.AreaId);
        }
    }
}
