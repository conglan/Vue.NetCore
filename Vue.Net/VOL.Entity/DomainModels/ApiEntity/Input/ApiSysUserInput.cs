using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VOL.Entity.DomainModels
{
    public class ApiSysUserInput
    {
        /// <summary>
        ///用户名
        /// </summary>
        [Display(Name = "用户名")]
        [MaxLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }

        /// <summary>
        ///密码
        /// </summary>
        [Display(Name = "密码")]
        [MaxLength(400)]
        [Column(TypeName = "nvarchar(400)")]
        [Required(AllowEmptyStrings = false)]
        public string UserPwd { get; set; }

        /// <summary>
        ///手机号
        /// </summary>
        [Display(Name = "手机号")]
        [MaxLength(22)]
        [Column(TypeName = "nvarchar(22)")]
        [Required(AllowEmptyStrings = false)]
        public string PhoneNo { get; set; }
    }
}