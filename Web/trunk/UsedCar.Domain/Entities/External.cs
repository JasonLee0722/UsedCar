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
    /// 外部配置
    /// </summary>
    [Table("External")]
    public class External
    {
        /// <summary>
        /// 全球唯一标识
        /// </summary>
        [Key]
        public string GUID { set; get; }

        /// <summary>
        /// 电动天窗
        /// </summary>
        public string PowerSunroof { set; get; }

        /// <summary>
        /// 全景天窗
        /// </summary>
        public string VistaSunroof { set; get; }

        /// <summary>
        /// 氙气大灯
        /// </summary>
        public string HID { set; get; }

        /// <summary>
        /// LED大灯
        /// </summary>
        public string LED { set; get; }

        /// <summary>
        /// 自动头灯
        /// </summary>
        public string AHL { set; get; }

        /// <summary>
        /// 前雾灯
        /// </summary>
        public string FFL { set; get; }

        /// <summary>
        /// 前电动车窗
        /// </summary>
        public string FPW { set; get; }

        /// <summary>
        /// 后电动车窗
        /// </summary>
        public string RPW { set; get; }

        /// <summary>
        /// 后视镜电动调节
        /// </summary>
        public string PowerMirror { set; get; }

        /// <summary>
        /// 后视镜加热
        /// </summary>
        public string HeatMirror { set; get; }
    }
}
