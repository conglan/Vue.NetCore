using System;
using System.ComponentModel.DataAnnotations;

namespace VOL.Entity
{
    public class BaseEntity : KeyEntity
    {
        /// <summary>
        /// 创建人
        /// </summary>
        [Display(Name = "创建人")]
        public Guid? CreateId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Display(Name = "创建时间")]
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        [Display(Name = "修改人")]
        public Guid? ModifyId { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [Display(Name = "修改时间")]
        public DateTime? ModifyDate { get; set; }
    }

    public class KeyEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Display(Name = "主键ID")]
        [Key]
        public Guid Id { get; set; }
    }

    public class FullEntity : BaseEntity
    {
        /// <summary>
        /// 删除人
        /// </summary>
        [Display(Name = "删除人")]
        public Guid? DeleteId { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [Display(Name = "修改时间")]
        public DateTime? DeleteDate { get; set; }
    }


}