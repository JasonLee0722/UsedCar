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
    /// 内部配置
    /// </summary>
    [Table("Internal")]
    public class Internal
    {
        /// <summary>
        /// 全球唯一标示
        /// </summary>
        [Key]
        public string GUID { set; get; }

        /// <summary>
        /// 真皮座椅（标配/无/加装）
        /// </summary>
        public string LeatherSeat { set; get; }

        /// <summary>
        /// 座椅加热
        /// </summary>
        public string HeatSeat { set; get; }

        /// <summary>
        /// 座椅通风
        /// </summary>
        public string AirSeat { set; get; }

        /// <summary>
        /// 多功能方向盘
        /// </summary>
        public string MFW { set; get; }

        /// <summary>
        /// 定速巡航
        /// </summary>
        public string CCS { set; get; }

        /// <summary>
        /// GPS导航
        /// </summary>
        public string GPS { set; get; }

        /// <summary>
        /// 倒车雷达
        /// </summary>
        public string PDC { set; get; }

        /// <summary>
        /// 倒车影像系统
        /// </summary>
        public string RIS { set; get; }

        /// <summary>
        /// 空调控制方式
        /// </summary>
        public string ACC { set; get; }
    }
}
