using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VOL.Core.Controllers.Basic;
using VOL.Core.Enums;
using VOL.Core.Filters;
using VOL.Entity.DomainModels;
using VOL.System.IServices;

namespace VOL.System.Controllers
{
    [Route("api/SysMenu")]
    [ApiController, JWTAuthorize()]
    public partial class SysMenuController : ApiBaseController<ISysMenuService>
    {
        private ISysMenuService _service { get; set; }
        public SysMenuController(ISysMenuService service) :
            base("System", "System", "SysMenu", service)
        {
            _service = service;
        } 
    }
}
