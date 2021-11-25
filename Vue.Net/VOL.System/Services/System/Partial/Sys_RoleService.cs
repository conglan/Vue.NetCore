using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VOL.Core.Extensions;
using VOL.Core.ManageUser;
using VOL.Core.Services;
using VOL.Core.UserManager;
using VOL.Core.Utilities;
using VOL.Entity;
using VOL.Entity.DomainModels;

namespace VOL.System.Services
{
    public partial class SysRoleService
    {
        private WebResponseContent _responseContent = new WebResponseContent();
        public override PageGridData<SysRole> GetPageData(PageDataOptions pageData)
        {
            //角色Id=1默认为超级管理员角色，界面上不显示此角色
            QueryRelativeExpression = (IQueryable<SysRole> queryable) =>
            {
                if (UserContext.Current.IsSuperAdmin)
                {
                    return queryable;
                }
                List<Guid> roleIds = GetAllChildrenRoleIdAndSelf();
                return queryable.Where(x => roleIds.Contains(x.Id));
            };
            return base.GetPageData(pageData);
        }
        /// <summary>
        /// 编辑权限时，获取当前用户的所有菜单权限
        /// </summary>
        /// <returns></returns>
        public async Task<WebResponseContent> GetCurrentUserTreePermission()
        {
            return await GetUserTreePermission(UserContext.Current.RoleId);
        }

        /// <summary>
        /// 编辑权限时，获取指定角色的所有菜单权限
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<WebResponseContent> GetUserTreePermission(Guid roleId)
        {
            if (!UserContext.IsRoleIdSuperAdmin(roleId) && UserContext.Current.RoleId != roleId)
            {
                if (!(await GetAllChildrenAsync(UserContext.Current.RoleId)).Exists(x => x.Id == roleId))
                {
                    return _responseContent.Error("没有权限获取此角色的权限信息");
                }
            }
            //获取用户权限
            List<Permissions> permissions = UserContext.Current.GetPermissionList(roleId);
            //权限用户权限查询所有的菜单信息
            List<SysMenu> menus = await Task.Run(() => SysMenuService.Instance.GetUserMenuList(roleId));
            //获取当前用户权限如:(Add,Search)对应的显示文本信息如:Add：添加，Search:查询
            var data = menus.Select(x => new UserPermissions
            {
                Id = x.Id,
                Pid = x.ParentId,
                Text = x.MenuName,
                Actions = GetActions(x.Id, x.Actions, permissions, roleId)
            });
            return _responseContent.OK(null, data);
        }

        private List<SysActions> GetActions(Guid menuId, List<SysActions> menuActions, List<Permissions> permissions, Guid roleId)
        {
            if (UserContext.IsRoleIdSuperAdmin(roleId))
            {
                return menuActions;
            }

            return menuActions.Where(p => permissions
                 .Exists(w => menuId == w.MenuId
                 && w.UserAuthArr.Contains(p.Value)))
                  .ToList();
        }

        private List<RoleNodes> rolesChildren = new List<RoleNodes>();

        /// <summary>
        /// 编辑权限时获取当前用户下的所有角色与当前用户的菜单权限
        /// </summary>
        /// <returns></returns>
        public async Task<WebResponseContent> GetCurrentTreePermission()
        {
            _responseContent = await GetCurrentUserTreePermission();
            Guid roleId = UserContext.Current.RoleId;
            return _responseContent.OK(null, new
            {
                tree = _responseContent.Data,
                roles = await GetAllChildrenAsync(roleId)
            });
        }

        private List<RoleNodes> roles = null;

        /// <summary>
        /// 获取当前角色下的所有角色包括自己的角色Id
        /// </summary>
        /// <returns></returns>
        public List<Guid> GetAllChildrenRoleIdAndSelf()
        {
            Guid roleId = UserContext.Current.RoleId;
            List<Guid> roleIds = GetAllChildren(roleId).Select(x => x.Id).ToList();
            roleIds.Add(roleId);
            return roleIds;
        }


        /// <summary>
        /// 获取当前角色下的所有角色
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public List<RoleNodes> GetAllChildren(Guid roleId)
        {
            roles = GetAllRoleQueryable(roleId).ToList();
            return GetAllChildrenNodes(roleId);
        }

        public async Task<List<RoleNodes>> GetAllChildrenAsync(Guid roleId)
        {
            roles = await GetAllRoleQueryable(roleId).ToListAsync();
            return GetAllChildrenNodes(roleId);
        }
        private IQueryable<RoleNodes> GetAllRoleQueryable(Guid roleId)
        {
            return repository
                   .FindAsIQueryable(
                   x => x.Enable == EnableEnum.启用)
                   .Select(
                   s => new RoleNodes()
                   {
                       Id = s.Id,
                       ParentId = s.ParentId,
                       RoleName = s.RoleName
                   });
        }

        public async Task<List<Guid>> GetAllChildrenRoleIdAsync(Guid roleId)
        {
            return (await GetAllChildrenAsync(roleId)).Select(x => x.Id).ToList();
        }


        public List<Guid> GetAllChildrenRoleId(Guid roleId)
        {
            return GetAllChildren(roleId).Select(x => x.Id).ToList();
        }

        private List<RoleNodes> GetAllChildrenNodes(Guid roleId)
        {
            if (UserContext.IsRoleIdSuperAdmin(roleId)) return roles;
            Dictionary<Guid, bool> completedRoles = new Dictionary<Guid, bool>();
            rolesChildren = GetChildren(roleId, completedRoles);
            //2021.07.11增加无限递归异常数据移除当前节点
            if (rolesChildren.Any(x => x.Id == roleId))
            {
                return rolesChildren.Where(x => x.Id != roleId).ToList();
            }
            return rolesChildren;
        }
        /// <summary>
        /// 递归获取所有子节点权限
        /// </summary>
        /// <param name="roleId"></param>
        private List<RoleNodes> GetChildren(Guid roleId, Dictionary<Guid, bool> completedRoles)
        {
            roles.ForEach(x =>
            {
                if (x.ParentId == roleId)
                {
                    if (completedRoles.TryGetValue(x.Id, out bool isWrite))
                    {
                        if (!isWrite)
                        {
                            roles.Where(x => x.Id == roleId).FirstOrDefault().ParentId = Guid.Empty;
                            Logger.Error($"sysroleservice获取子角色异常RoleContext,角色id:{x.Id}");
                            Console.WriteLine($"sysroleservice获取子角色异常RoleContext,角色id:{x.Id}");
                            completedRoles[x.Id] = true;
                        }
                        return;
                    }
                    rolesChildren.Add(x);

                    completedRoles[x.Id] = false;


                    if (x.Id != x.ParentId)
                    {
                        GetChildren(x.Id, completedRoles);
                    }
                }
            });
            return rolesChildren;
        }

        /// <summary>
        /// 保存角色权限
        /// </summary>
        /// <param name="userPermissions"></param>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public async Task<WebResponseContent> SavePermission(List<UserPermissions> userPermissions, Guid roleId)
        {

            string message = "";
            try
            {
                UserInfo user = UserContext.Current.UserInfo;
                if (!(await GetAllChildrenAsync(user.RoleId)).Exists(x => x.Id == roleId))
                    return _responseContent.Error("没有权限修改此角色的权限信息");
                //当前用户的权限
                List<Permissions> permissions = UserContext.Current.Permissions;

                List<Guid> originalMeunIds = new List<Guid>();
                //被分配角色的权限
                List<SysRoleAuth> roleAuths = await repository.FindAsync<SysRoleAuth>(x => x.RoleId == roleId);
                List<SysRoleAuth> updateAuths = new List<SysRoleAuth>();
                foreach (UserPermissions x in userPermissions)
                {
                    Permissions per = permissions.Where(p => p.MenuId == x.Id).FirstOrDefault();
                    //不能分配超过当前用户的权限
                    if (per == null) continue;
                    //per.UserAuthArr.Contains(a.Value)校验权限范围
                    string[] arr = x.Actions == null || x.Actions.Count == 0
                      ? new string[0]
                      : x.Actions.Where(a => per.UserAuthArr.Contains(a.Value))
                      .Select(s => s.Value).ToArray();

                    //如果当前权限没有分配过，设置Auth_Id默认为0，表示新增的权限
                    var auth = roleAuths.Where(r => r.MenuId == x.Id).Select(s => new { s.Id, s.AuthValue, s.MenuId }).FirstOrDefault();
                    string newAuthValue = string.Join(",", arr);
                    //权限没有发生变化则不处理
                    if (auth == null || auth.AuthValue != newAuthValue)
                    {
                        updateAuths.Add(new SysRoleAuth()
                        {
                            RoleId = roleId,
                            MenuId = x.Id,
                            AuthValue = string.Join(",", arr),
                            Id = auth == null ? Guid.Empty : auth.Id,
                            ModifyId = UserContext.Current.UserId,
                            ModifyDate = DateTime.Now,
                            CreateId = UserContext.Current.UserId,
                            CreateDate = DateTime.Now,
                        });
                    }
                    else
                    {
                        originalMeunIds.Add(auth.MenuId);
                    }

                }
                //更新权限
                repository.UpdateRange(updateAuths.Where(x => x.Id != Guid.Empty), x => new
                {
                    x.MenuId,
                    x.AuthValue,
                    x.ModifyId,
                    x.ModifyDate
                });
                //新增的权限
                repository.AddRange(updateAuths.Where(x => x.Id != Guid.Empty));

                //获取权限取消的权限
                Guid[] authIds = roleAuths.Where(x => userPermissions.Select(u => u.Id)
                 .ToList().Contains(x.MenuId) || originalMeunIds.Contains(x.MenuId))
                .Select(s => s.Id)
                .ToArray();
                List<SysRoleAuth> delAuths = roleAuths.Where(x => x.AuthValue != "" && !authIds.Contains(x.Id)).ToList();
                delAuths.ForEach(x =>
                {
                    x.AuthValue = "";
                });
                //将取消的权限设置为""
                repository.UpdateRange(delAuths, x => new
                {
                    x.MenuId,
                    x.AuthValue,
                    x.ModifyId,
                    x.ModifyDate
                });

                int addCount = updateAuths.Where(x => x.Id != Guid.Empty).Count();
                int updateCount = updateAuths.Where(x => x.Id != Guid.Empty).Count();
                await repository.SaveChangesAsync();

                string _version = DateTime.Now.ToString("yyyyMMddHHMMssfff");
                //标识缓存已更新
                base.CacheContext.Add(roleId.GetRoleIdKey(), _version);

                _responseContent.OK($"保存成功：新增加配菜单权限{addCount}条,更新菜单{updateCount}条,删除权限{delAuths.Count()}条");
            }
            catch (Exception ex)
            {
                message = "异常信息：" + ex.Message + ex.StackTrace + ",";
            }
            finally
            {
                Logger.Info($"权限分配置:{message}{_responseContent.Message}");
            }

            return _responseContent;
        }


        public override WebResponseContent Add(SaveModel saveDataModel)
        {
            AddOnExecuting = (SysRole role, object obj) =>
            {
                return ValidateRoleName(role, x => x.RoleName == role.RoleName);
            };
            return RemoveCache(base.Add(saveDataModel));
        }

        public override WebResponseContent Del(object[] keys, bool delList = true)
        {
            return RemoveCache(base.Del(keys, delList));
        }

        private WebResponseContent ValidateRoleName(SysRole role, Expression<Func<SysRole, bool>> predicate)
        {
            if (repository.Exists(predicate))
            {
                return _responseContent.Error($"角色名【{role.RoleName}】已存在,请设置其他角色名");
            }
            return _responseContent.OK();
        }

        public override WebResponseContent Update(SaveModel saveModel)
        {
            UpdateOnExecuting = (SysRole role, object obj1, object obj2, List<object> obj3) =>
            {
                //2020.05.07新增禁止选择上级角色为自己
                if (role.Id == role.ParentId)
                {
                    return _responseContent.Error($"上级角色不能选择自己");
                }
                if (role.Id == UserContext.Current.RoleId)
                {
                    return _responseContent.Error($"不能修改自己的角色");
                }
                if (repository.Exists(x => x.Id == role.ParentId && x.ParentId == role.Id))
                {
                    return _responseContent.Error($"不能选择此上级角色，选择的上级角色与当前角色形成依赖关系");
                }
                return ValidateRoleName(role, x => x.RoleName == role.RoleName && x.Id != role.Id);
            };
            return RemoveCache(base.Update(saveModel));
        }
        private WebResponseContent RemoveCache(WebResponseContent webResponse)
        {
            if (webResponse.Status)
            {
                RoleContext.Refresh();
            }
            return webResponse;
        }
    }

    public class RoleNodes
    {
        public Guid Id { get; set; }
        public Guid ParentId { get; set; }
        public string RoleName { get; set; }
    }
    public class UserPermissions
    {
        public Guid Id { get; set; }
        public Guid Pid { get; set; }
        public string Text { get; set; }
        public List<SysActions> Actions { get; set; }
    }
}
