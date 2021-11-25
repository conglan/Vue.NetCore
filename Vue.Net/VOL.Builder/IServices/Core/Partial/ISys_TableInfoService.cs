using VOL.Core.BaseProvider;
using VOL.Entity.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using VOL.Core.Utilities;
using System;

namespace VOL.Builder.IServices
{
    public partial interface ISysTableInfoService
    {
        Task<(string, string)> GetTableTree();

        string CreateEntityModel(SysTableInfo tableInfo);

        WebResponseContent SaveEidt(SysTableInfo sysTableInfo);

        string CreateServices(string tableName, string nameSpace, string foldername, bool webController, bool apiController);

        string CreatePage(SysTableInfo sysTableInfo);

        string CreateVuePage(SysTableInfo sysTableInfo, string vuePath);

        object LoadTable(Guid parentId, string tableName, string columnCNName, string nameSpace, string foldername, Guid table_Id, bool isTreeLoad);
        Task<WebResponseContent> SyncTable(string tableName);
        Task<WebResponseContent> DelTree(Guid tableId);
    }
}
