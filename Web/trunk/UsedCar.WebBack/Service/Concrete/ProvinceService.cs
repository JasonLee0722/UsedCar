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

    public class ProvinceService : IProvinceService
    {
        //EFDbContext db = new EFDbContext();

        public Province GetProvinceByName(string Name)
        {
            //GET api/Province/{id}
            string url = string.Format("{0}/api/Province/{1}", WEBUtility.WebApiHost, Name);
            return NetUtility.GetHttpWithToken<Province>(url);
        }
        public Province GetProvinceByShortName(string ShortName)
        {
            //GET api/Province/{id}
            string url = string.Format("{0}/api/Province/{1}", WEBUtility.WebApiHost, ShortName);
            return NetUtility.GetHttpWithToken<Province>(url);
        }
        public IList<Province> GetProvinceList()
        {
            //POST api/Province/all
            string url = string.Format("{0}/api/Province/all", WEBUtility.WebApiHost);
            return NetUtility.GetHttpWithToken<IList<Province>>(url);
        }
    }
}
