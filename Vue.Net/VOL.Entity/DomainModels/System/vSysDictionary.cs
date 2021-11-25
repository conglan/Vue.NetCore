using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VOL.Entity.DomainModels
{
    [Entity(TableCnName = "字典视图")]
    public class vSysDictionary : KeyEntity
    {
        /// <summary>
        ///
        /// </summary>
        [Display(Name = "DicValue")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string DicValue { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "DicListId")]
        [Column(TypeName = "int")]
        public int DicListId { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "DicName")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string DicName { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "Enable")]
        [Column(TypeName = "tinyint")]
        public byte? Enable { get; set; }

        /// <summary>
        ///
        /// </summary>
        [Display(Name = "DicNo")]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        [Required(AllowEmptyStrings = false)]
        public string DicNo { get; set; }
    }
}