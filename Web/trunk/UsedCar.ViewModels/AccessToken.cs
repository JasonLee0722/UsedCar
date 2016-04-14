using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsedCar.ViewModels
{
    public class AccessToken
    {
        /// <summary>
        /// 过期时间（秒）
        /// </summary>
        public int expires_in { get; set; }

        public string access_token { get; set; }
        
        public string token_type { get; set; }
    }
}
