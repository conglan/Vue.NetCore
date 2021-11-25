using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VOL.Entity.DomainModels
{
    [Table("SysTableInfo")]
    [Entity(DetailTable = new Type[] { typeof(SysTableColumn) })]
    public class SysTableInfo : KeyEntity
    {
        [MaxLength(50)]
        public string CnName { get; set; }

        [MaxLength(100)]
        public string ColumnCNName { get; set; }

        [MaxLength(2000)]
        public string DBServer { get; set; }

        [MaxLength(200)]
        public string DataTableType { get; set; }

        [MaxLength(200)]
        public string DetailCnName { get; set; }

        [MaxLength(200)]
        public string DetailName { get; set; }

        [MaxLength(100)]
        public string EditorType { get; set; }

        public EnableEnum? Enable { get; set; }

        [MaxLength(200)]
        public string ExpressField { get; set; }

        [MaxLength(200)]
        public string FolderName { get; set; }

        [MaxLength(200)]
        public string Namespace { get; set; }

        public int? OrderNo { get; set; }
        public Guid? ParentId { get; set; }

        [MaxLength(100)]
        public string RichText { get; set; }

        [MaxLength(50)]
        public string SortName { get; set; }

        [MaxLength(50)]
        public string TableName { get; set; }

        [MaxLength(100)]
        public string TableTrueName { get; set; }

        [MaxLength(100)]
        public string UploadField { get; set; }

        public int? UploadMaxCount { get; set; }

        [ForeignKey("TableId")]
        public List<SysTableColumn> TableColumns { get; set; }
    }
}