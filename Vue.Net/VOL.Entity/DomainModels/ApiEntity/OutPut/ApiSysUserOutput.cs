using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOL.Entity;

namespace VOL.Entity.DomainModels
{
    public class ApiSysUserOutput
    {
        /// <summary>
       ///用户名
       /// </summary>
       [Display(Name ="用户名")]
       [MaxLength(200)]
       [Column(TypeName="nvarchar(200)")]
       
       [Required(AllowEmptyStrings=false)]
       public string UserName { get; set; }

       /// <summary>
       ///部门
       /// </summary>
       [Display(Name ="部门")]
       [MaxLength(300)]
       [Column(TypeName="nvarchar(300)")]
       
       public string DeptName { get; set; }

       /// <summary>
       ///角色
       /// </summary>
       [Display(Name ="角色")]
       [Column(TypeName="int")]
       
       [Required(AllowEmptyStrings=false)]
       public Guid RoleId { get; set; }

       
    }
}