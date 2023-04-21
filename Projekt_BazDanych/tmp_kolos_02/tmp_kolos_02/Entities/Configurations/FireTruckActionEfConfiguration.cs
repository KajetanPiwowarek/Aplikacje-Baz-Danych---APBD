using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tmp_kolos_02.Entities.Configurations
{
    public class FireTruckActionEfConfiguration : IEntityTypeConfiguration<FireTruckAction>
    {
        public void Configure(EntityTypeBuilder<FireTruckAction> builder)
        {
            builder.HasKey(e => new { e.IdFireTruck, e.IdAction }).HasName("FireTruckAction_pk");

            builder.Property(e => e.AssigmentDate).IsRequired();

            builder.HasOne(e => e.IdFireTruckNavigation)
                .WithMany(e => e.FireTruckActions)
                .HasForeignKey(e => e.IdFireTruck)
                .HasConstraintName("FireTruckAction_FireTruck")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.IdActionNavigation)
                .WithMany(e => e.FireTruckActions)
                .HasForeignKey(e => e.IdAction)
                .HasConstraintName("FireTruckAction_Action")
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("FireTruck_Action");
        }
    }
}
