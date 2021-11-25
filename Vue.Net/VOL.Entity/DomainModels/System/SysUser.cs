/*
 *代码由框架生成,任何更改都可能导致被代码生成器覆盖
 *如果数据库字段发生变化，请在代码生器重新生成此Model
 */

using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VOL.Entity.DomainModels
{
    [Table("SysUser")]
    [Entity(ApiInput = typeof(ApiSysUserInput), ApiOutput = typeof(ApiSysUserOutput))]
    public class SysUser : BaseEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Display(Name = "用户名")]
        [MaxLength(200)]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码")]
        [MaxLength(400)]
        [JsonIgnore]
        public string UserPwd { get; set; }

        /// <summary>
        /// 用户真实姓名
        /// </summary>
        [Display(Name = "用户真实姓名")]
        [MaxLength(40)]
        public string UserTrueName { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        [Display(Name = "Token")]
        [MaxLength(1000)]
        public string Token { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Display(Name = "地址")]
        [MaxLength(400)]
        public string Address { get; set; }

        /// <summary>
        /// 登陆设备类型
        /// </summary>
        [Display(Name = "登陆设备类型")]
        public int? AppType { get; set; }

        /// <summary>
        /// 部门ID
        /// </summary>
        [Display(Name = "部门ID")]
        [Column(TypeName = "int")]
        public int? DeptId { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        [Display(Name = "部门")]
        [MaxLength(300)]
        public string DeptName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Display(Name = "Email")]
        [MaxLength(200)]
        public string Email { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        [Display(Name = "是否可用")]
        public EnableEnum Enable { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别")]
        public GenderEnum? Gender { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [Display(Name = "头像")]
        [MaxLength(400)]
        public string HeadImageUrl { get; set; }

        /// <summary>
        /// 是否手机用户
        /// </summary>
        [Display(Name = "是否手机用户")]
        public int IsRegregisterPhone { get; set; }

        /// <summary>
        /// 最后登陆时间
        /// </summary>
        [Display(Name = "最后登陆时间")]
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// 最后密码修改时间
        /// </summary>
        [Display(Name = "最后密码修改时间")]
        public DateTime? LastModifyPwdDate { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        [Display(Name = "角色")]
        public Guid RoleId { get; set; }

        /// <summary>
        /// 角色id
        /// </summary>
        [Display(Name = "RoleName")]
        [MaxLength(300)]
        public string RoleName { get; set; }

        /// <summary>
        ///手机号
        /// </summary>
        [Display(Name = "手机号")]
        [MaxLength(22)]
        public string PhoneNo { get; set; }

        /// <summary>
        ///排序号
        /// </summary>
        [Display(Name = "排序号")]
        [Column(TypeName = "int")]
        public int? OrderNo { get; set; }

        /// <summary>
        ///备注
        /// </summary>
        [Display(Name = "备注")]
        [MaxLength(400)]
        [Column(TypeName = "nvarchar(400)")]
        public string Remark { get; set; }
    }
}