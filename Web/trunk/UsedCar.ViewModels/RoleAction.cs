using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedCar.ViewModels
{
    /// <summary>
    /// 角色权限
    /// </summary>
    public class RoleAction
    {
        public int ID { get; set; }
        /// <summary>
        /// 关联Role表ID字段
        /// </summary>
        public int RoleID { get; set; }
        /// <summary>
        /// 关联Action表ID字段
        /// </summary>
        public int ActionID { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime? AddTime { get; set; }
        [NotMapped]
        public string ActionName { get; set; }
    }
}
