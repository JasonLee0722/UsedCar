using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedCar.ViewModels
{

    [Table("CarSerie")]
    public class CarSerie : BaseModelGuid
    {
        /// <summary>
        /// 关联CarBrand表ID字段
        /// </summary>
        public int? BrandID { get; set; }
        /// <summary>
        /// 车系如：奥迪A4L,奥迪A4L(进口)
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 车系图片
        /// </summary>
        public byte[] Pic { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PicType { get; set; }
        public DateTime? AddTime { get; set; }
        public int State { get; set; }

    }
}
