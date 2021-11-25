using VOL.Builder.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.EFDbContext;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Builder.Repositories
{
    public partial class SysTableInfoRepository : RepositoryBase<SysTableInfo>, ISysTableInfoRepository
    {
        public SysTableInfoRepository(VOLContext dbContext)
        : base(dbContext)
        {

        }
        public static ISysTableInfoRepository GetService
        {
            get { return AutofacContainerModule.GetService<ISysTableInfoRepository>(); }
        }
    }
}

