using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedCar.ViewModels
{
    [Table("DicType")]
    public class DicType : BaseModelGuid
    {
        /// <summary>
        /// 字典编码
        /// </summary>
        public string TypeCode { get; set; }
        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// 是否树形结构(0：不是；1：是)
        /// </summary>
        public int? IsTree { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int? Sort { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        public string Remark { get; set; }

    }
}
