using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels;
using System.Linq;
using VOL.Core.Extensions;
using System.Collections.Generic;
using VOL.Core.Enums;

namespace VOL.System.Services
{
    public partial class SysDictionaryListService
    {

        public override PageGridData<SysDictionaryList> GetPageData(PageDataOptions pageData)
        {
            base.OrderByExpression = x => new Dictionary<object, QueryOrderBy>() { {
                    x.OrderNo,QueryOrderBy.Desc
                },
                {
                    x.Id,QueryOrderBy.Asc
                }
            };
            return base.GetPageData(pageData);
        }
    }
}

