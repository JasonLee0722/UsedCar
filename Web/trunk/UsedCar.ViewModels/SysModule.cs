using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace UsedCar.ViewModels
{
    public class SysModule
    {
        public int ID { get; set; }
        /// <summary>
        /// 系统功能模块名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 父模块ID
        /// </summary>
        public int ParentID { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
    }
}
