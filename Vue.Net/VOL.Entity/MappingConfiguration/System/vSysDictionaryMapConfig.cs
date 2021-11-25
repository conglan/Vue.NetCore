using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Framework.Entity.MappingConfiguration
{
    public class vSysDictionaryMapConfig : EntityMappingConfiguration<vSysDictionary>
    {
        public override void Map(EntityTypeBuilder<vSysDictionary> builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
    }
}


