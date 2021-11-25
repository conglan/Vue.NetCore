using VOL.Builder.IRepositories;
using VOL.Builder.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.Builder.Services
{
    public partial class SysTableInfoService : ServiceBase<SysTableInfo, ISysTableInfoRepository>, ISysTableInfoService, IDependency
    {
        public  SysTableInfoService(ISysTableInfoRepository repository)
             : base(repository) 
        { 
           Init(repository);   
        }
        public static ISysTableInfoService Instance
        {
           get { return AutofacContainerModule.GetService<ISysTableInfoService>(); }
        }
    }
}

