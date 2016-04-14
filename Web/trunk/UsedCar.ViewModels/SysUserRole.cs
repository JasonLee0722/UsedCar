using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedCar.ViewModels
{
    public class SysUserRole
    {
        public int ID { get; set; }
        /// <summary>
        /// 关联SysUser表GUID字段
        /// </summary>
        public string SysUser { get; set; }
        /// <summary>
        /// 关联Role表ID字段
        /// </summary>
        public int RoleID { get; set; }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 角色名称
        /// </summary>
        [NotMapped]
        public string RoleName { get; set; }
    }
}
