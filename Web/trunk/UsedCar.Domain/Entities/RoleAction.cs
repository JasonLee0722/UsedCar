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
    /// 系统角色与系统功能模块动作关联
    /// </summary>
    [Table("RoleAction")]
    public class RoleAction
    {
        /// <summary>
        /// 主键，唯一标识
        /// </summary>
        [Key, ScaffoldColumn(false)]
        public int Id { set; get; }

        /// <summary>
        /// SysRole.Id
        /// </summary>
        /// <value>The role identifier.</value>
        public int RoleId { set; get; }

        /// <summary>
        /// SysAction.Id
        /// </summary>
        /// <value>The action identifier.</value>
        public int ActionId { set; get; }

        /// <summary>
        /// SysAction.Name
        /// </summary>
        [NotMapped]
        public string ActionName { set; get; }
    }
}

