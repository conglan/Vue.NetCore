/*
 *Author：jxx
 *Contact：283591387@qq.com
 *Date：2018-07-01
 * 此代码由框架生成，请勿随意更改
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VOL.Entity.DomainModels
{
    [Table("SysRole")]
    [Entity(TableCnName = "角色管理")]
    public class SysRole : BaseEntity
    {
        /// <summary>
        /// 父级ID
        /// </summary>
        [Display(Name = "父级ID")]
        public Guid ParentId { get; set; }

        /// <summary>
        ///角色名称
        /// </summary>
        [Display(Name = "角色名称")]
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string RoleName { get; set; }

        /// <summary>
        ///部门ID
        /// </summary>
        [Display(Name = "部门ID")]
        public Guid? DeptId { get; set; }

        /// <summary>
        ///部门名称
        /// </summary>
        [Display(Name = "部门名称")]
        [MaxLength(50)]
        public string DeptName { get; set; }

        /// <summary>
        ///排序
        /// </summary>
        [Display(Name = "排序")]
        public int? OrderNo { get; set; }

        /// <summary>
        ///是否启用
        /// </summary>
        [Display(Name = "是否启用")]
        public EnableEnum? Enable { get; set; }

        /// <summary>
        /// 是否超级管理员
        /// </summary>
        public bool? SuperAdmin { get; set; }

        [ForeignKey("RoleId")]
        public List<SysRoleAuth> RoleAuths { get; set; }
    }
}