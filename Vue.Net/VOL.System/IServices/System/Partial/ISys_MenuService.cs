using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VOL.Core.Utilities;
using VOL.Entity.DomainModels;

namespace VOL.System.IServices
{
    public partial interface ISysMenuService
    {
        Task<object> GetMenu();
        List<SysMenu> GetCurrentMenuList();

        List<SysMenu> GetUserMenuList(Guid roleId);

        Task<object> GetCurrentMenuActionList();

        Task<object> GetMenuActionList(Guid roleId);
        Task<WebResponseContent> Save(SysMenu menu);

        Task<object> GetTreeItem(Guid menuId);
    }
}

