/*
 *Author：jxx
 *Contact：283591387@qq.com
 *Date：2018-07-01
 * 此代码由框架生成，请勿随意更改
 */

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VOL.Entity.DomainModels
{
    [Table("SysLog")]
    [Entity(TableCnName = "系统日志")]
    public class SysLog : BaseEntity
    {
        /// <summary>
        ///开始时间
        /// </summary>
        [Display(Name = "开始时间")]
        public DateTime? BeginDate { get; set; }

        /// <summary>
        ///浏览器类型
        /// </summary>
        [Display(Name = "浏览器类型")]
        [MaxLength(200)]
        public string BrowserType { get; set; }

        /// <summary>
        ///时长(毫秒)
        /// </summary>
        [Display(Name = "时长(毫秒)")]
        public int? ElapsedTime { get; set; }

        /// <summary>
        ///结束时间
        /// </summary>
        [Display(Name = "结束时间")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        ///异常信息
        /// </summary>
        [Display(Name = "异常信息")]
        [MaxLength(10000)]
        public string ExceptionInfo { get; set; }

        /// <summary>
        ///日志类型
        /// </summary>
        [Display(Name = "日志类型")]
        [MaxLength(50)]
        public string LogType { get; set; }

        /// <summary>
        ///请求参数
        /// </summary>
        [Display(Name = "请求参数")]
        [MaxLength(10000)]
        public string RequestParameter { get; set; }

        /// <summary>
        ///响应参数
        /// </summary>
        [Display(Name = "响应参数")]
        [MaxLength(10000)]
        public string ResponseParameter { get; set; }

        /// <summary>
        ///角色ID
        /// </summary>
        [Display(Name = "角色ID")]
        public Guid? RoleId { get; set; }

        /// <summary>
        ///服务器IP
        /// </summary>
        [Display(Name = "服务器IP")]
        [MaxLength(100)]
        public string ServiceIP { get; set; }

        /// <summary>
        ///响应状态
        /// </summary>
        [Display(Name = "响应状态")]
        public int? Success { get; set; }

        /// <summary>
        ///请求地址
        /// </summary>
        [Display(Name = "请求地址")]
        [MaxLength(30000)]
        public string Url { get; set; }

        /// <summary>
        ///用户IP
        /// </summary>
        [Display(Name = "用户IP")]
        [MaxLength(100)]
        public string UserIP { get; set; }

        /// <summary>
        ///用户名称
        /// </summary>
        [Display(Name = "用户名称")]
        [MaxLength(30000)]
        public string UserName { get; set; }

        /// <summary>
        ///用户ID
        /// </summary>
        [Display(Name = "用户ID")]
        public Guid? UserId { get; set; }
    }
}