using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace UsedCar.WebAPIs.Models
{
    public class Message
    {
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { set; get; }

        /// <summary>
        /// 状态
        /// </summary>
        public bool State { set; get; }
    }

    public enum MessageContent
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        successful = 1,

        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        failed = 2,

        /// <summary>
        /// 重复
        /// </summary>en
        [Description("重复数据")]
        exist = 3,

        /// <summary>
        /// 关联
        /// </summary>
        [Description("已关联")]
        connected = 4,

        /// <summary>
        /// 嵌套
        /// </summary>
        [Description("嵌套")]
        nested = 5,

        /// <summary>
        /// 错误
        /// </summary>
        [Description("系统错误")]
        error = 6
    }

    public class EnumService
    {
        /// <summary>
        /// 获取属性说明
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetDescription(Enum obj)
        {
            string objName = obj.ToString();
            Type t = obj.GetType();
            FieldInfo fi = t.GetField(objName);
            DescriptionAttribute[] arrDesc = (DescriptionAttribute[])fi
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return arrDesc[0].Description;
        }
    }
}