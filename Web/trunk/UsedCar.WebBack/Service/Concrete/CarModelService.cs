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
    public class CarModelService : ICarModelService
    {

        public CarModel getCarModelDetail(int id)
        {
            //GET api/carmodel/{id}
            string url = string.Format("{0}/api/carmodel/{1}", WEBUtility.WebApiHost, id);
            return NetUtility.GetHttpWithToken<CarModel>(url);
        }
        public CarModel getCarModelDetail(string Name)
        {
            //GET api/carmodel/{id}
            string url = string.Format("{0}/api/carmodel/{1}", WEBUtility.WebApiHost, Name);
            return NetUtility.GetHttpWithToken<CarModel>(url);
        }
        public IPagedList<CarModel> GetCarModelList(int PageSize, int PageIndex)
        {
            //GET api/carmodel/all
            string url = string.Format("{0}/api/carmodel/all", WEBUtility.WebApiHost);
            var models = NetUtility.GetHttpWithToken<IList<CarModel>>(url);
            return models.ToPagedList<CarModel>(PageIndex, PageSize);

        }
        public IList<CarModel> GetCarModelList(int CarSerieID)
        {
            //GET api/carmodel/all
            string url = string.Format("{0}/api/carmodel/all", WEBUtility.WebApiHost);
            var models = NetUtility.GetHttpWithToken<IList<CarModel>>(url);
            return models;
        }
        public IPagedList<CarModel> GetCarModelList(int PageSize, int PageIndex, int CarSerieId)
        {
            //GET api/carmodel/all
            string url = string.Format("{0}/api/carmodel/all", WEBUtility.WebApiHost);
            var models = NetUtility.GetHttpWithToken<IList<CarModel>>(url);
            return models.ToPagedList<CarModel>(PageIndex, PageSize);

        }
        public int AddCarModel(CarModel CarModel)
        {
            //POST api/carmodel/add
            string url = string.Format("{0}/api/carmodel/add", WEBUtility.WebApiHost);
            return NetUtility.PostHttpWithToken(url, CarModel);
        }
        public int EditCarModel(CarModel CarModel)
        {
            //POST api/carmodel/add
            string url = string.Format("{0}/api/carmodel/add", WEBUtility.WebApiHost);
            return NetUtility.PostHttpWithToken(url, CarModel);
        }
        public bool checkNameUnique(string Nname)
        {
            throw new NotImplementedException();
            //return db.CarModels.Where(m => m.Name == Nname).Count() > 0;
        }
        public int DeleteCarModel(string ids)
        {
            //POST api/carmodel/delete?id={id}
            string url = string.Format("{0}/api/carmodel/delete?id={1}", WEBUtility.WebApiHost, ids);
            return NetUtility.PostHttpWithToken(url);
        }
    }
}
