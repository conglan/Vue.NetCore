﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VOL.Core.Filters;
using VOL.Entity.DomainModels;

namespace VOL.Builder.Controllers
{
    /// <summary>
    /// 限定权限只有角色1的才能访问
    /// </summary>
    //[ActionPermission(1)]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("Builder")]
    public partial class SysTableInfoController
    {
        [Route("Index")]
        public  override ActionResult Manager()
        {
            (string, string) treeData = Service.GetTableTree().Result;
            ViewData["TreeList"] = treeData.Item1;
            ViewData["NameSpaceArray"] = treeData.Item2;
            return View("~/Views/Builder/Manager.cshtml");
        }

        [Route("CreatePage")]
        public async Task<ActionResult> CreatePage([ModelBinder]SysTableInfo sysTableInfo)
        {
            return Content(await Task.Run(() => Service.CreatePage(sysTableInfo)));
        }

        [Route("CreateModel")]
        public async Task<ActionResult> CreateEntityModel([ModelBinder]SysTableInfo tableInfo)
        {
            return Content(await Task.Run(() => Service.CreateEntityModel(tableInfo)));
        }
        [Route("Eidt")]
        public async Task<ActionResult> SaveEidt([ModelBinder]SysTableInfo tableInfo)
        {
            return Json(await Task.Run(() => Service.SaveEidt(tableInfo)));
        }
        [Route("CreateServices")]
        public async Task<ActionResult> CreateServices(string tableName, string nameSpace, string foldername, bool? partial, bool? api)
        {
            return Content(await Task.Run(() => Service.CreateServices(tableName, nameSpace, foldername,true, false)));
        }
        [Route("LoadTableInfo")]
        public async Task<ActionResult> LoadTable(Guid parentId, string tableName, string columnCNName, string nameSpace, string foldername, Guid table_Id, bool isTreeLoad)
        {
            return Json(await Task.Run(() => Service.LoadTable(parentId, tableName, columnCNName, nameSpace, foldername, table_Id, isTreeLoad)));

        }
    }
}

