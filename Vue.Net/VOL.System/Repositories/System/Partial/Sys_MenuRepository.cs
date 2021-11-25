using VOL.Core.EFDbContext;

namespace VOL.System.Repositories
{
    public partial class SysMenuRepository
    {
        public override VOLContext DbContext => base.DbContext;
    }
}