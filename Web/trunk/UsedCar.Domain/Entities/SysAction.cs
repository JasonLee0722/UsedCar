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
    /// 系统功能模块动作，如：增加、删除、修改
    /// </summary>
    [Table("SystemAction")]
    public class SysAction
    {
        /// <summary>
        /// 主键，唯一标识
        /// </summary>
        [Key, ScaffoldColumn(false)]
        public int Id { set; get; }

        /// <summary>
        /// 动作名称
        /// </summary>
        /// <value>The name.</value>
        public string Name { set; get; }

        /// <summary>
        /// 动作代码，如：add、delete、modify、admin
        /// </summary>
        /// <value>The code.</value>
        [JsonIgnore]
        public string Code { set; get; }

        /// <summary>
        /// 系统功能模块Id
        /// </summary>
        /// <value>The module identifier.</value>
//        [ConcurrencyCheck] 并发
        public int ModuleId { set; get; }

        /// <summary>
        /// 排序
        /// </summary>
        /// <value>The sort.</value>
        public int Sort { set; get; }

        /// <summary>
        /// 系统功能模块名称
        /// </summary>
        /// <value>The name of the module.</value>
        [NotMapped]
        public string ModuleName { set; get; }
    }
}

