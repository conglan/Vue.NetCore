using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VOL.Entity.DomainModels
{
    [Table("SysRoleAuth")]
    [Entity(TableCnName = "角色身份验证")]
    public class SysRoleAuth : BaseEntity
    {
        /// <summary>
        /// 角色ID
        /// </summary>
        [Display(Name = "角色ID")]
        public Guid? RoleId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [Display(Name = "用户ID")]
        public Guid? UserId { get; set; }

        /// <summary>
        /// 菜单ID
        /// </summary>
        [Display(Name = "菜单ID")]
        public Guid MenuId { get; set; }

        /// <summary>
        /// 用户权限
        /// </summary>
        [Display(Name = "用户权限")]
        [MaxLength(1000)]
        public string AuthValue { get; set; }
    }
}