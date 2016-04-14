

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedCar.ViewModels
{

    [Table("CarModel")]
    public class CarModel : BaseModelGuid
    {
        /// <summary>
        /// 关联CarSerie表ID字段
        /// </summary>
        public int? SerieID { get; set; }
        /// <summary>
        /// 车型名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 生成年份
        /// </summary>
        public int? Year { get; set; }
        public string MT_AT { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Addtime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? State { get; set; }
        /// <summary>
        /// 车系参数【兼容保留，请使用CarBrand中的此字段】(OBD用，福特：1；大众（奥迪）：2；宝马：3；）
        /// </summary>
        public short? dev_cs { get; set; }
        /// <summary>
        /// 车型参数(OBD用，福特以外均为0)
        /// </summary>
        public short? dev_ct { get; set; }
    }
}
