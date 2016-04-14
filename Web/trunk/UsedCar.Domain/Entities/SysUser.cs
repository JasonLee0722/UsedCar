using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UsedCar.Domain
{
    /// <summary>
    /// 系统用户
    /// </summary>
    [Table("SystemUser")]
    public class SysUser
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key, ScaffoldColumn(false)]
        public int Id { set; get; }

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { set; get; }

        /// <summary>
        /// 登录密码
        /// </summary>
        [JsonIgnore]
        public string LoginPwd { set; get; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 身份证
        /// </summary>
        public string CardNo { set; get; }

        /// <summary>
        /// 状态（1：可用，0：不可用）
        /// </summary>
        public int State { set; get; }

        /// <summary>
        /// 电话（手机号）
        /// </summary>
        public string Phone { set; get; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { set; get; }

        /// <summary>
        /// 添加时间
        /// </summary>
        [JsonIgnore]
        public string AddTime { set; get; }

        /// <summary>
        /// 动作权限
        /// </summary>
        [NotMapped]
        public IQueryable<SysAction> HasActions { set; get; }
    }
}
