using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedCar.ViewModels
{
    /// <summary>
    /// 城市车牌头对应表
    /// </summary>
    //[Table("PlateLocated")]
    public class PlateLocated
    {
        /// <summary>
        /// 车牌头
        /// </summary>
        [Key]
        public string Plate { get; set; }
        /// <summary>
        /// 城市名称（对应城市表NAME）
        /// </summary>
        public string City { get; set; }

    }
}
