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
    public class CarSerieService : ICarSerieService
    {
        public CarSerie getCarSerieDetail(int id)
        {
            //GET api/carserie/{id}
            string url = string.Format("{0}/api/carserie/{1}", WEBUtility.WebApiHost, id);
            return NetUtility.GetHttpWithToken<CarSerie>(url);
        }
        public CarSerie getCarSerieDetail(string serie)
        {
            //GET api/carserie/{id}
            string url = string.Format("{0}/api/carserie/{1}", WEBUtility.WebApiHost, serie);
            return NetUtility.GetHttpWithToken<CarSerie>(url);
        }
        public IPagedList<CarSerie> GetCarSerieList(int PageSize, int PageIndex, int CarBrandId)
        {
            //GET api/carserie/all
            string url = string.Format("{0}/api/carserie/all", WEBUtility.WebApiHost);
            var models = NetUtility.GetHttpWithToken<IList<CarSerie>>(url);
            return models.ToPagedList<CarSerie>(PageIndex, PageSize);

        }
        public IList<CarSerie> GetCarSerieList(int CarBrandId)
        {

            //GET api/carserie/all
            string url = string.Format("{0}/api/carserie/all", WEBUtility.WebApiHost);
            var models = NetUtility.GetHttpWithToken<IList<CarSerie>>(url);
            return models;
        }
        public int AddCarSerie(CarSerie model)
        {
            //POST api/dictype/add
            string url = string.Format("{0}/api/dictype/add", WEBUtility.WebApiHost);
            return NetUtility.PostHttpWithToken(url, model);
        }
        public int EditCarSerie(CarSerie model)
        {
            //POST api/dictype/add
            string url = string.Format("{0}/api/dictype/add", WEBUtility.WebApiHost);
            return NetUtility.PostHttpWithToken(url, model);
        }
        public bool checkNameUnique(string Nname)
        {
            throw new NotImplementedException();
            //return db.CarSeries.Where(m => m.Name == Nname).Count() > 0;
        }
        public int DeleteCarSerie(string ids)
        {
            //POST api/carserie/delete?id={id}
            string url = string.Format("{0}/api/carserie/delete?id={1}", WEBUtility.WebApiHost, ids);
            return NetUtility.PostHttpWithToken(url);
        }

    }
}
