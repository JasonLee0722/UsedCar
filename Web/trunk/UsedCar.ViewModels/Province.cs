using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedCar.ViewModels
{
    /// <summary>
    /// 城市
    /// </summary>
    [Table("Province")]
    public class Province : BaseModelGuid
    {
        public string Name { get; set; }

        public string Code { get; set; }

    }
}
