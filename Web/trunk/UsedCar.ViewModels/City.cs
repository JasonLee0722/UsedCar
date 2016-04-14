using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedCar.ViewModels
{
    /// <summary>
    /// 城市
    /// </summary>
    [Table("City")]
    public class City : BaseModelGuid
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Abbr { get; set; }

        public int? Engineno { get; set; }

        public int? Classno { get; set; }

        public int? Registno { get; set; }
        public string ProvinceName { get; set; }
    }
}
