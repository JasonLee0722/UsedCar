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
    /// 用户与角色关联
    /// </summary>
    [Table("UserRole")]
    public class UserRole
    {
        /// <summary>
        /// 主键，唯一标识
        /// </summary>
        /// <value>The identifier.</value>
        [Key, ScaffoldColumn(false)]
        public int Id { set; get; }

        /// <summary>
        /// SysUer.Id
        /// </summary>
        /// <value>The user identifier.</value>
        public int UserId { set; get; }

        /// <summary>
        /// SysRole.Id
        /// </summary>
        /// <value>The role identifier.</value>
        public int RoleId { set; get; }

        /// <summary>
        /// 状态
        /// </summary>
        /// <value>The state.</value>
        public int State { set; get; }

        /// <summary>
        /// 添加时间
        /// </summary>
        /// <value>The add time.</value>
        [JsonIgnore]
        public DateTime AddTime { set; get; }

        /// <summary>
        /// 角色名称
        /// </summary>
        /// <value>The name of the role.</value>
        [NotMapped]
        public string RoleName { set; get; }
    }
}

