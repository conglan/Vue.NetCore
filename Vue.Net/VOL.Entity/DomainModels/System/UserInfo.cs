using System;

namespace VOL.Entity.DomainModels
{
    public class UserInfo
    {
        public Guid UserId { get; set; }

        /// <summary>
        /// 多个角色ID
        /// </summary>
        public Guid RoleId { get; set; }

        public string RoleName { get; set; }
        public string UserName { get; set; }
        public string UserTrueName { get; set; }
        public EnableEnum Enable { get; set; }
        public string Token { get; set; }
    }
}