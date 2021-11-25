using System;

namespace VOL.Entity.DomainModels
{
    public class Permissions
    {
        public Guid MenuId { get; set; }
        public Guid ParentId { get; set; }
        public string TableName { get; set; }
        public string MenuAuth { get; set; }
        public string UserAuth { get; set; }

        /// <summary>
        /// 当前用户权限,存储的是权限的值，如:Add,Search等
        /// </summary>
        public string[] UserAuthArr { get; set; }
    }
}