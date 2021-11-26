﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VOL.Core.Enums;
using VOL.Core.Filters;
using VOL.Entity.DomainModels;
using VOL.System.IServices;

namespace VOL.System.Controllers
{
    public partial class SysMenuController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, HttpPost, Route("getTreeMenu")]
        //2019.10.24屏蔽用户查询自己权限菜单
        public async Task<IActionResult> GetTreeMenu()
        {
            return Json(await _service.GetCurrentMenuActionList());
        }
        [HttpPost, Route("getMenu")]
        [ApiActionPermission("SysMenu", ActionPermissionOptions.Search)]
        public async Task<IActionResult> GetMenu()
        {
            return Json(await _service.GetMenu());
        }

        [HttpPost, Route("getTreeItem")]
        [ApiActionPermission("SysMenu", ActionPermissionOptions.Search)]
        public async Task<IActionResult> GetTreeItem(Guid menuId)
        {
            return Json(await _service.GetTreeItem(menuId));
        }

        //只有角色ID为1的才能进行保存操作
        [HttpPost, Route("save"), ApiActionPermission(ActionRolePermission.SuperAdmin)]
        public async Task<ActionResult> Save([FromBody] SysMenu menu)
        {
            return Json(await _service.Save(menu));
        }

        /// <summary>
        /// 限制只能超级管理员才删除菜单 
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        [ApiActionPermission(ActionRolePermission.SuperAdmin)]
        [HttpPost, Route("delMenu")]
        public  async   Task<ActionResult> DelMenu(Guid menuId)
        {
            Core.Utilities.WebResponseContent webResponse = new Core.Utilities.WebResponseContent();
            var repository = Repositories.SysMenuRepository.Instance;
            if (await repository.ExistsAsync(x => x.ParentId == menuId))
            {  
                return Json(webResponse.Error("当前菜单存在子菜单,请先删除子菜单!"));
            }
            repository.Delete(new SysMenu()
            {
                Id = menuId
            },true);
            return Json(webResponse.OK("删除成功"));
        }

    }
}