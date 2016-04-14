using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsedCar.ViewModels;

namespace Service.Abstract
{
    public interface ICityService
    {
        IList<City> GetCityList(string ProvinceName);
        IList<City> GetCityListByShortName(string ShortName);
        City GetCityByPlateLocated(string CarHead);
        City GetCityByCity(string name);
    }
}
