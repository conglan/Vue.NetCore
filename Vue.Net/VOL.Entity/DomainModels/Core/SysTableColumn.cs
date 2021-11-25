using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VOL.Entity.DomainModels
{
    [Table("SysTableColumn")]
    public class SysTableColumn : BaseEntity
    {
        /// <summary>
        /// TableId
        /// <summary>
        [Display(Name = "TableId")]
        public Guid TableId { get; set; }

        /// <summary>
        /// 列名
        /// <summary>
        [Display(Name = "列名")]
        [MaxLength(100)]
        public string ColumnName { get; set; }

        /// <summary>
        /// 列名(中国)
        /// <summary>
        [Display(Name = "列名(中国)")]
        [MaxLength(100)]
        public string ColumnCnName { get; set; }

        /// <summary>
        /// 列类型
        /// <summary>
        [Display(Name = "列类型")]
        public string ColumnType { get; set; }

        /// <summary>
        /// 列宽
        /// <summary>
        [Display(Name = "列宽")]
        public int? ColumnWidth { get; set; }

        /// <summary>
        /// 列格式
        /// </summary>
        [Display(Name = "列格式")]
        public string ColumnFormat { get; set; }

        [MaxLength(50)]
        public string DropNo { get; set; }

        [MaxLength(200)]
        public string EditType { get; set; }

        public string Script { get; set; }
        public int? ApiInPut { get; set; }
        public int? ApiIsNull { get; set; }
        public int? ApiOutPut { get; set; }
        public int? ColSize { get; set; }
        public int? EditColNo { get; set; }
        public int? EditRowNo { get; set; }
        public EnableEnum? Enable { get; set; }
        public int? IsColumnData { get; set; }
        public int? IsDisplay { get; set; }
        public string TableName { get; set; }
        public int? IsImage { get; set; }
        public int? IsKey { get; set; }
        public int? IsNull { get; set; }
        public int? IsReadDataset { get; set; }
        public int? Maxlength { get; set; }
        public int? OrderNo { get; set; }
        public int? SearchColNo { get; set; }
        public int? SearchRowNo { get; set; }
        public string SearchType { get; set; }
        public int? Sortable { get; set; }
    }
}