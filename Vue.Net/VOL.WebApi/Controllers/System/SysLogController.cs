using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.System.IServices;

namespace VOL.System.Controllers
{
    [Route("api/SysLog")]
    public partial class SysLogController : ApiBaseController<ISysLogService>
    {
        public SysLogController(ISysLogService service)
        : base("System", "System", "SysLog", service)
        {
        }
    }
}