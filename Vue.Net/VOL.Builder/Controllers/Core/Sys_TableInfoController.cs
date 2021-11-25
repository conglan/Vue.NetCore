using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOL.Builder.IServices;
using VOL.Core.Controllers.Basic;
using Microsoft.AspNetCore.Mvc;

namespace VOL.Builder.Controllers
{
    public partial class SysTableInfoController : WebBaseController<ISysTableInfoService>
    {
        public SysTableInfoController(ISysTableInfoService service)
        : base("Builder","Core","SysTableInfo", service)
        {
        }
    }
}

