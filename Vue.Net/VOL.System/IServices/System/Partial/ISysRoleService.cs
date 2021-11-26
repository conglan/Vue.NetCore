using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VOL.Core.Utilities;
using VOL.System.Services;

namespace VOL.System.IServices
{
    public partial interface ISysRoleService
    {
        Task<WebResponseContent> GetUserTreePermission(Guid roleId);

        Task<WebResponseContent> GetCurrentUserTreePermission();

        Task<WebResponseContent> GetCurrentTreePermission();

        Task<WebResponseContent> SavePermission(List<UserPermissions> userPermissions, Guid roleId);

        /// <summary>
        /// 获取角色下所有的角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<List<RoleNodes>> GetAllChildrenAsync(Guid roleId);

        /// <summary>
        /// 获取角色下所有的角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        List<RoleNodes> GetAllChildren(Guid roleId);

        /// <summary>
        /// 获取角色下所有的角色Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        Task<List<Guid>> GetAllChildrenRoleIdAsync(Guid roleId);

        List<Guid> GetAllChildrenRoleId(Guid roleId);

        /// <summary>
        /// 获取当前角色下的所有角色包括自己的角色Id
        /// </summary>
        /// <returns></returns>
        List<Guid> GetAllChildrenRoleIdAndSelf();
    }
}