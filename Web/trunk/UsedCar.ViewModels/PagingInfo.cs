using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UsedCar.WebAPIs.Models
{
    public class PagingInfo<T>
    {
        public IQueryable<T> Objects { set; get; }

        public int TotalItems { set; get; }

        public int ItemPerPage { set; get; }

        public int CurrentPage { set; get; }

        public int TotalPages 
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalItems / ItemPerPage);
            }
        }
    }
}