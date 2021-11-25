using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VOL.Core.Controllers.Basic;
using VOL.Core.Enums;
using VOL.Core.Filters;
using VOL.Entity.AttributeManager;
using VOL.Entity.DomainModels;
using VOL.System.IServices;

namespace VOL.System.Controllers
{
    [Route("api/SysRole")]
    [PermissionTable(Name = "SysRole")]
    public partial class SysRoleController : ApiBaseController<ISysRoleService>
    {
        public SysRoleController(ISysRoleService service)
        : base("System", "System", "SysRole", service)
        {

        }
    }
}


