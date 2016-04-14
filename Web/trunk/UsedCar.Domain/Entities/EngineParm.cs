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
    /// 发动机参数
    /// </summary>
    [Table("EngineParm")]
    public class EngineParm
    {
        /// <summary>
        /// 全球唯一标识
        /// </summary>
        [Key]
        public string GUID { set; get; }

        /// <summary>
        /// 进气形式
        /// </summary>
        public string AirIntake { set; get; }

        /// <summary>
        /// 气缸，如：L4、V6
        /// </summary>
        public string Cylinder { set; get; }

        /// <summary>
        /// 最大马力，单位：Ps
        /// </summary>
        public int FullPower { set; get; }

        /// <summary>
        /// 最大扭矩，单位：N*m
        /// </summary>
        public int Torque { set; get; }

        /// <summary>
        /// 燃料类型（汽油、柴油）
        /// </summary>
        public string FuelType { set; get; }

        /// <summary>
        /// 燃油标号（93#、97#）
        /// </summary>
        public int FuelMode { set; get; }

        /// <summary>
        /// 供油方式
        /// </summary>
        public string FSW { set; get; }

        /// <summary>
        /// 排放标准
        /// </summary>
        public string ES { set; get; }
    }
}
