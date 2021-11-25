using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.System.IServices;

namespace VOL.System.Controllers
{
    [Route("api/SysUser")]
    [PermissionTable(Name = "SysUser")]
    public partial class SysUserController : ApiBaseController<ISysUserService>
    {
        public SysUserController(ISysUserService service)
        : base("System", "System", "SysUser", service)
        {
            //, IMemoryCache cache
        }
    }
}