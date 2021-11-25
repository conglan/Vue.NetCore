using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Framework.Entity.MappingConfiguration
{
    public class SysLogMapConfig : EntityMappingConfiguration<SysLog>
    {
        public override void Map(EntityTypeBuilder<SysLog> builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
    }
}


