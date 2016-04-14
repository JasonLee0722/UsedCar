using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsedCar.Domain
{
    /// <summary>
    /// 底盘及制动
    /// </summary>
    [Table("Chassis")]
    public class Chassis
    {
        /// <summary>
        /// 全球唯一标识
        /// </summary>
        [Key]
        public string GUID { set; get; }

        /// <summary>
        /// 驱动方式
        /// </summary>
        public string DriveMode { set; get; }

        /// <summary>
        /// 助力类型（电动、机械）
        /// </summary>
        public string PST { set; get; }

        /// <summary>
        /// 前悬挂类型
        /// </summary>
        public string FST { set; get; }

        /// <summary>
        /// 后悬挂类型
        /// </summary>
        public string RST { set; get; }

        /// <summary>
        /// 前制动类型
        /// </summary>
        public string FBT { set; get; }

        /// <summary>
        /// 后制动类型
        /// </summary>
        public string RBT { set; get; }

        /// <summary>
        /// 驻车制动类型
        /// </summary>
        public string PBT { set; get; }

        /// <summary>
        /// 前轮胎规格
        /// </summary>
        public string FTS { set; get; }

        /// <summary>
        /// 后轮胎规格
        /// </summary>
        public string RTS { set; get; }
    }
}
