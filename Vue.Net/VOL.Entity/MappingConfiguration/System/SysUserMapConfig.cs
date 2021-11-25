using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VOL.Entity.DomainModels;

namespace VOL.Entity.MappingConfiguration
{
    public class SysUserMapConfig : EntityMappingConfiguration<SysUser>
    {
        public override void Map(EntityTypeBuilder<SysUser>
        builderTable)
        {
            //b.Property(x => x.StorageName).HasMaxLength(45);
        }
    }
}