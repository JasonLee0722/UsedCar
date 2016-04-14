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
    /// 系统功能模块
    /// </summary>
    [Table("SystemModule")]
    public class SysModule
    {
        /// <summary>
        /// 主键
        /// </summary>
        /// <value>The identifier.</value>
        [Key, ScaffoldColumn(false)]
        public int Id { set; get; }

        /// <summary>
        /// 模块名称
        /// </summary>
        /// <value>The name.</value>
        public string Name { set; get; }

        /// <summary>
        /// 排序
        /// </summary>
        /// <value>The sort.</value>
        public int Sort { set; get; }

        /// <summary>
        /// 父模块Id
        /// </summary>
        /// <value>The parent identifier.</value>
        public int ParentId { set; get; }
    }
}

