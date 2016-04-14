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
    /// 车辆图片
    /// </summary>
    [Table("CarPic")]
    public class CarPic
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public int Id { set; get; }

        /// <summary>
        /// Car.GUID
        /// </summary>
        public string GUID { set; get; }

        /// <summary>
        /// 原图
        /// </summary>
        public string Original { set; get; }

        /// <summary>
        /// 缩略图
        /// </summary>
        public string Thumbnail { set; get; }
    }
}