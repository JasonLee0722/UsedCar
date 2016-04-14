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
    /// 系统角色
    /// </summary>
    [Table("SystemRole")]
    public class SysRole
    {
        /// <summary>
        /// 主键，唯一标识
        /// </summary>
        [Key, ScaffoldColumn(false)]
        public int Id { set; get; }

        /// <summary>
        /// 角色名称
        /// </summary>
        /// <value>The name.</value>
        public string Name { set; get; }

        /// <summary>
        /// 角色描述
        /// </summary>
        [Column("describe")]
        public string Desc { set; get; }

        /// <summary>
        /// 角色添加时间
        /// </summary>
        [JsonIgnore]
        public DateTime AddTime { set; get; }
    }
}

