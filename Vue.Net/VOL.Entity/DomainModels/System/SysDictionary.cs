/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果数据库字段发生变化，请在代码生器重新生成此Model
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VOL.Entity.DomainModels
{
    [Table("SysDictionary")]
    [Entity(TableCnName = "字典数据", DetailTable = new Type[] { typeof(SysDictionaryList) }, DetailTableCnName = "字典明细")]
    public class SysDictionary : BaseEntity
    {
        /// <summary>
        /// 字典编号
        /// </summary>
        [Display(Name = "字典编号")]
        [MaxLength(100)]
        public string DicNo { get; set; }

        /// <summary>
        /// 字典名称
        /// </summary>
        [Display(Name = "字典名称")]
        [MaxLength(100)]
        public string DicName { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        [Display(Name = "父级ID")]
        public Guid ParentId { get; set; }

        /// <summary>
        /// 配置项
        /// </summary>
        [Display(Name = "配置项")]
        [MaxLength(10000)]
        public string Config { get; set; }

        /// <summary>
        /// sql语句
        /// </summary>
        [Display(Name = "sql语句")]
        [MaxLength(10000)]
        public string DbSql { get; set; }

        /// <summary>
        /// DBServer
        /// </summary>
        [Display(Name = "DBServer")]
        [MaxLength(10000)]
        public string DBServer { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        [Display(Name = "排序号")]
        public int? OrderNo { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display(Name = "备注")]
        [MaxLength(2000)]
        public string Remark { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [Display(Name = "是否启用")]
        public EnableEnum Enable { get; set; }

        [Display(Name = "字典明细")]
        [ForeignKey("DicId")]
        public List<SysDictionaryList> SysDictionaryList { get; set; }
    }
}