using Common.Utils;
using PagedList;
using Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsedCar.ViewModels;

namespace Service.Concrete
{
    public class CityService : ICityService
    {
        public IList<City> GetCityList(string ProvinceName)
        {
            //GET api/City/all
            string url = string.Format("{0}/api/City/all", WEBUtility.WebApiHost);
            return NetUtility.GetHttpWithToken<IList<City>>(url);
        }
        public IList<City> GetCityListByShortName(string ShortName)
        {
            //GET api/City/all
            string url = string.Format("{0}/api/City/all", WEBUtility.WebApiHost);
            return NetUtility.GetHttpWithToken<IList<City>>(url);
        }
        public City GetCityByPlateLocated(string CarHead)
        {
            //GET api/City/all
            string url = string.Format("{0}/api/City/all", WEBUtility.WebApiHost);
            return NetUtility.GetHttpWithToken<City>(url);
        }
        public City GetCityByCity(string name)
        {
            //GET api/City/all
            string url = string.Format("{0}/api/City/all", WEBUtility.WebApiHost);
            return NetUtility.GetHttpWithToken<City>(url);
        }
    }
}
