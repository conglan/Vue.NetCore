using VOL.System.IRepositories;
using VOL.System.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.System.Services
{
    public partial class SysLogService : ServiceBase<SysLog, ISysLogRepository>, ISysLogService, IDependency
    {
        public SysLogService(ISysLogRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static ISysLogService Instance
        {
           get { return AutofacContainerModule.GetService<ISysLogService>(); }
        }
    }
}

