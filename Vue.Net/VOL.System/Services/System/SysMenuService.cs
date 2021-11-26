using VOL.System.IRepositories;
using VOL.System.IServices;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;

namespace VOL.System.Services
{
    public partial class SysMenuService : ServiceBase<SysMenu, ISysMenuRepository>, ISysMenuService, IDependency
    {
        public SysMenuService(ISysMenuRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static ISysMenuService Instance
        {
           get { return AutofacContainerModule.GetService<ISysMenuService>(); }
        }
    }
}

