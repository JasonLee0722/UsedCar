using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedCar.ViewModels
{
    [Table("DicName")]
    public class DicName : BaseModelGuid
    {
        /// <summary>
        /// 键值（字典值）
        /// </summary>
        public string KeyValue { get; set; }
        /// <summary>
        /// 字典名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 类型ID，和字典类型表关联
        /// </summary>
        public string DicTypeCode { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort { get; set; }

        /// <summary>
        /// 状态(0:禁用；1：启用)
        /// </summary>
        public int? State { get; set; }
    }
}
