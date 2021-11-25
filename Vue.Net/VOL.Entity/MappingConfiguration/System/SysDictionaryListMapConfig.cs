using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Entity.MappingConfiguration
{
    public class SysDictionaryListMapConfig : EntityMappingConfiguration<SysDictionaryList>
    {
        public override void Map(EntityTypeBuilder<SysDictionaryList>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}

