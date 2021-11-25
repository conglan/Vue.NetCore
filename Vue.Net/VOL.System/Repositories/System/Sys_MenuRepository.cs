using VOL.System.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Core.EFDbContext;
using VOL.Entity.DomainModels;

namespace VOL.System.Repositories
{
    public partial class SysMenuRepository : RepositoryBase<SysMenu>, ISysMenuRepository
    {
        public SysMenuRepository(VOLContext dbContext)
        : base(dbContext)
        {

        }
        public static ISysMenuRepository Instance
        {
            get { return AutofacContainerModule.GetService<ISysMenuRepository>(); }
        }
    }
}

