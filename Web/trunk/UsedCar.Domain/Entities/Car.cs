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
    /// 汽车基本信息
    /// </summary>
    [Table("Car")]
    public class Car
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int Id { set; get; }

        /// <summary>
        /// 全球唯一标识
        /// </summary>
        public string GUID { set; get; }

        /// <summary>
        /// Seller.Id 卖家
        /// </summary>
        public int SellerId { set; get; }

        /// <summary>
        /// Buyer.Id 买家
        /// </summary>
        public int BuyerId { set; get; }

        /// <summary>
        /// 品牌
        /// </summary>
        public string Brand { set; get; }

        /// <summary>
        /// 车系
        /// </summary>
        public string Series { set; get; }

        /// <summary>
        /// 车型
        /// </summary>
        public string Model { set; get; }

        /// <summary>
        /// 排量
        /// </summary>
        public float CC { set; get; }

        /// <summary>
        /// 颜色
        /// </summary>
        public string Color { set; get; }

        /// <summary>
        /// 国别：德系、法系、日系、国产等
        /// </summary>
        public string Made { set; get; }

        /// <summary>
        /// 上牌时间
        /// </summary>
        public DateTime IssueDate { set; get; }

        /// <summary>
        /// 里程数
        /// </summary>
        public float Mileage { set; get; }

        /// <summary>
        /// 上牌地
        /// </summary>
        public string IssueAddress { set; get; }

        /// <summary>
        /// 变速箱：手动、自动
        /// </summary>
        public string GearBox { set; get; }

        /// <summary>
        /// 排放标准
        /// </summary>
        public string ES { set; get; }

        /// <summary>
        /// 年检到期时间
        /// </summary>
        public DateTime NJ { set; get; }

        /// <summary>
        /// 交强险到期时间
        /// </summary>
        public DateTime JQX { set; get; }

        /// <summary>
        /// 商业险到期时间
        /// </summary>
        public DateTime SYX { set; get; }

        /// <summary>
        /// 车辆过户几次
        /// </summary>
        public int TransferTimes { set; get; }

        /// <summary>
        /// 车辆描述
        /// </summary>
        [Column("describe")]
        public string Desc { set; get; }

        /// <summary>
        /// 车主报价
        /// </summary>
        public decimal Price { set; get; }

        /// <summary>
        /// 是否成交（1：成交，0：未成交）
        /// </summary>
        public int Deal { set; get; }

        /// <summary>
        /// 降价急售
        /// </summary>
        public decimal Sale { set; get; }

        /// <summary>
        /// 练手车（1：是，0：不是）
        /// </summary>
        public int LSC { set; get; }

        /// <summary>
        /// 准新车（1：是，0：不是）
        /// </summary>
        public int LikeNew { set; get; }

        /// <summary>
        /// 基本参数，Basic.GUID
        /// </summary>
        public string Basic { set; get; }

        /// <summary>
        /// 发动机参数，Engine.GUID
        /// </summary>
        public string Engine { set; get; }

        /// <summary>
        /// 底盘及制动，Chassis.GUID
        /// </summary>
        public string Chassis { set; get; }

        /// <summary>
        /// 安全配置，Security.GUID
        /// </summary>
        public string security { set; get; }

        /// <summary>
        /// 外部配置，Eexternal.GUID
        /// </summary>
        public string Eexternal { set; get; }

        /// <summary>
        /// 内部配置，Internal.GUID
        /// </summary>
        public string Internal { set; get; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { set; get; }

    }
}
