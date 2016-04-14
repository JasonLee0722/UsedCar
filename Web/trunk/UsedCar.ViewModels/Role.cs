using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace UsedCar.ViewModels
{
    public class Role
    {
        public int ID { get; set; }
        /// <summary>
        /// 角色名称，唯一值
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 角色备注说明
        /// </summary>
        public string Desc { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddTime { get; set; }
    }
}
