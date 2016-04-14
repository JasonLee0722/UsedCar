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
    /// 基本参数
    /// </summary>
    [Table("BasicParm")]
    public class BasicParm
    {
        /// <summary>
        /// 全球唯一标识
        /// </summary>
        [Key]
        public string GUID { set; get; }

        /// <summary>
        /// 生产厂商
        /// </summary>
        public string Firm { set; get; }

        /// <summary>
        /// 级别，如 B级车
        /// </summary>
        public string Class { set; get; }

        /// <summary>
        /// 变速箱（自动、手动）
        /// </summary>
        public string GearBox { set; get; }

        /// <summary>
        /// 车身结构
        /// </summary>
        public string Body { set; get; }

        /// <summary>
        /// 车身长度，单位：mm
        /// </summary>
        public int L { set; get; }

        /// <summary>
        /// 车身宽度，单位：mm
        /// </summary>
        public int W { set; get; }

        /// <summary>
        /// 车身高度，单位：mm
        /// </summary>
        public int H { set; get; }

        /// <summary>
        /// 轴距，单位：mm
        /// </summary>
        public int WheelBase { set; get; }

        /// <summary>
        /// 行李箱容积，单位：L
        /// </summary>
        public int Trunk { set; get; }

        /// <summary>
        /// 车身重量
        /// </summary>
        public int KG { set; get; }
    }
}
