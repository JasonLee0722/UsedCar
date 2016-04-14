

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedCar.ViewModels
{

    [Table("CarBrand")]
    public class CarBrand : BaseModelGuid
    {
        /// <summary>
        /// 车辆品牌，如奥迪，奔驰，长城
        /// </summary>
        public string Brand { get; set; }
        /// <summary>
        /// 品牌图片
        /// </summary>
        public byte[] Pic { get; set; }
        /// <summary>
        /// 车辆品牌中文首字母
        /// </summary>
        public string PicType { get; set; }
        public string Sort { get; set; }
        /// <summary>
        /// 品牌代码（福特：FORD；大众（奥迪）：VW；宝马：BMW；）
        /// </summary>
        public string BrandCode { get; set; }
        /// <summary>
        /// 车系参数(OBD用，福特：1；大众（奥迪）：2；宝马：3；）
        /// </summary>
        public short? dev_cs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AddTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? State { get; set; }
        [NotMapped]
        public int OBDType { get; set; }

    }
}
