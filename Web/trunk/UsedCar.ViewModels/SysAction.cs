using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedCar.ViewModels
{
    public class SysAction
    {
        public int ID { get; set; }
        /// <summary>
        /// 权限名称，唯一值
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 关联Module表ID字段
        /// </summary>
        public int ModuleID { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddTime { get; set; }
        
        public string ModuleName { get; set; }
    }
}
