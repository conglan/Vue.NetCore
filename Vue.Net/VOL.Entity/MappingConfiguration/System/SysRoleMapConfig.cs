using VOL.Entity.MappingConfiguration;
using VOL.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VOL.Framework.Entity.MappingConfiguration
{
    public class SysRoleMapConfig : EntityMappingConfiguration<SysRole>
    {
        public override void Map(EntityTypeBuilder<SysRole> builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
    }
}


