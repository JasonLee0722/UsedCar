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
    /// 安全配置
    /// </summary>
    [Table("Security")]
    public class Security
    {
        /// <summary>
        /// 全球唯一标识
        /// </summary>
        [Key]
        public string GUID { set; get; }

        /// <summary>
        /// 主驾驶安全气囊
        /// </summary>
        public string MDSAB { set; get; }

        /// <summary>
        /// 副驾驶安全气囊
        /// </summary>
        public string ADSAB { set; get; }

        /// <summary>
        /// 后排侧气囊
        /// </summary>
        public string FSAB { set; get; }

        /// <summary>
        /// 后排侧气囊
        /// </summary>
        public string RSAB { set; get; }

        /// <summary>
        /// 前排头部气囊
        /// </summary>
        public string FHAB { set; get; }

        /// <summary>
        /// 后排头部气囊
        /// </summary>
        public string RHAB { set; get; }

        /// <summary>
        /// 胎压监测
        /// </summary>
        public string TPMS { set; get; }

        /// <summary>
        /// 车内中控锁
        /// </summary>
        public string Lock { set; get; }

        /// <summary>
        /// 儿童座椅接口
        /// </summary>
        public string ISOFIX { set; get; }

        /// <summary>
        /// 无钥匙启动
        /// </summary>
        public string NoKey { set; get; }

        /// <summary>
        /// 防抱死系统(ABS)
        /// </summary>
        public string ABS { set; get; }

        /// <summary>
        /// 车身稳定控制(ESP)
        /// </summary>
        public string ESP { set; get; }
    }
}
