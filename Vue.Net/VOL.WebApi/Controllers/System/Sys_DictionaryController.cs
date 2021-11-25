using Microsoft.AspNetCore.Mvc;
using VOL.Core.Controllers.Basic;
using VOL.System.IServices;

namespace VOL.System.Controllers
{
    [Route("api/SysDictionary")]
    public partial class SysDictionaryController : ApiBaseController<ISysDictionaryService>
    {
        public SysDictionaryController(ISysDictionaryService service)
        : base("System", "System", "SysDictionary", service)
        {
        }
    }
}