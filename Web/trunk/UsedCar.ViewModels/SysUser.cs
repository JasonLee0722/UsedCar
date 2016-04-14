using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace UsedCar.ViewModels
{
    /// <summary>
    /// 系统用户
    /// </summary>
    public class SysUser
    {
        public int Id { set; get; }

        /// <summary>
        /// 登录名
        /// </summary>
        [Display(Name = "登录名")]
        public string LoginName { set; get; }

        /// <summary>
        /// 登陆密码
        /// </summary>
        [JsonIgnore]
        public string LoginPwd { set; get; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        public string Name { set; get; }

        /// <summary>
        /// 身份证
        /// </summary>
        [Display(Name = "身份证")]
        public string CardNo { set; get; }

        /// <summary>
        /// 1: 用户可用 0：用户不可用
        /// </summary>
        [Display(Name = "用户状态", Description = "1: 用户可用 0：用户不可用")]
        public int State { set; get; }

        public string StateName
        {
            get
            {
                if (State == 1)
                {
                    return "启用";
                }
                else
                    return "禁用";
            }
        }
        /// <summary>
        /// 手机号码
        /// </summary>
        [Display(Name = "手机号码")]
        public string Phone { set; get; }

        /// <summary>
        /// 地址
        /// </summary>
        [Display(Name = "地址")]
        public string Address { set; get; }
        /// <summary>
        /// 最高角色等级
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public int TopRoleLevel { get; set; }
        /// <summary>
        /// 拥有的动作
        /// </summary>
        [NotMapped]
        [JsonIgnore]
        public IList<SysAction> HasActions { get; set; }
    }
}
