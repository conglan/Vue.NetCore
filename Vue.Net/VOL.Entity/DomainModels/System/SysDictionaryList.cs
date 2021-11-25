/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果数据库字段发生变化，请在代码生器重新生成此Model
 */

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VOL.Entity.DomainModels
{
    [Table("SysDictionaryList")]
    [Entity(TableCnName = "字典明细")]
    public class SysDictionaryList : BaseEntity
    {
        /// <summary>
        ///数据源ID
        /// </summary>
        [Display(Name = "数据源ID")]
        public Guid? DicId { get; set; }

        /// <summary>
        ///数据源Value
        /// </summary>
        [Display(Name = "数据源Value")]
        [MaxLength(100)]
        public string DicValue { get; set; }

        /// <summary>
        ///数据源Text
        /// </summary>
        [Display(Name = "数据源Text")]
        [MaxLength(100)]
        public string DicName { get; set; }

        /// <summary>
        ///排序号
        /// </summary>
        [Display(Name = "排序号")]
        public int? OrderNo { get; set; }

        /// <summary>
        ///备注
        /// </summary>
        [Display(Name = "备注")]
        [MaxLength(2000)]
        public string Remark { get; set; }

        /// <summary>
        ///是否可用
        /// </summary>
        [Display(Name = "是否可用")]
        public EnableEnum Enable { get; set; }
    }
}