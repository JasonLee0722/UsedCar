using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsedCar.ViewModels;

namespace Service.Abstract
{
    public interface IProvinceService
    {
        Province GetProvinceByName(string Name);
        Province GetProvinceByShortName(string ShortName);
        IList<Province> GetProvinceList();
    }
}
