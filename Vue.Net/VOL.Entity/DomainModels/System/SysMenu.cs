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
    [Table("SysMenu")]
    [Entity(TableCnName = "菜单配置")]
    public class SysMenu : BaseEntity
    {
        /// <summary>
        /// 菜单名称
        /// </summary>
        [Display(Name = "菜单名称")]
        [MaxLength(50)]
        public string MenuName { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        [Display(Name = "权限")]
        [MaxLength(10000)]
        public string Auth { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [Display(Name = "图标")]
        [MaxLength(50)]
        public string Icon { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Display(Name = "描述")]
        [MaxLength(200)]
        public string Description { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [Display(Name = "是否启用")]
        public EnableEnum? Enable { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        [Display(Name = "排序号")]
        public int? OrderNo { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        [Display(Name = "表名")]
        [MaxLength(200)]
        public string TableName { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        [Display(Name = "父级ID")]
        public Guid ParentId { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        [Display(Name = "Url")]
        [MaxLength(10000)]
        public string Url { get; set; }

        [NotMapped]
        public List<SysActions> Actions { get; set; }
    }
}