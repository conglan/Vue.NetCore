using VOL.System.IRepositories;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Core.EFDbContext;
using VOL.Entity.DomainModels;

namespace VOL.System.Repositories
{
    public partial class SysLogRepository : RepositoryBase<SysLog>, ISysLogRepository
    {
        public SysLogRepository(VOLContext dbContext)
        : base(dbContext)
        {

        }
        public static ISysLogRepository GetService
        {
            get { return AutofacContainerModule.GetService<ISysLogRepository>(); }
        }
    }
}

