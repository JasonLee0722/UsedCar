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
    public class CarBrandService : ICarBrandService
    {
        public CarBrand getCarBrandDetail(int id)
        {
            //GET api/carbrand/{id}
            string url = string.Format("{0}/api/carbrand/{1}", WEBUtility.WebApiHost, id);
            return NetUtility.GetHttpWithToken<CarBrand>(url);
        }
        public CarBrand getCarBrandDetail(string Brand)
        {
            //GET api/carbrand/{id}
            string url = string.Format("{0}/api/carbrand/{1}", WEBUtility.WebApiHost, Brand);
            return NetUtility.GetHttpWithToken<CarBrand>(url);
        }
        public IPagedList<CarBrand> GetCarBrandList(int PageSize, int PageIndex)
        {
            //GET api/carbrand/all
            string url = string.Format("{0}/api/carbrand/all", WEBUtility.WebApiHost);
            var models = NetUtility.GetHttpWithToken<IList<CarBrand>>(url);
            return models.ToPagedList<CarBrand>(PageIndex, PageSize);

        }
        public IList<CarBrand> GetCarBrandList()
        {
            //GET api/carbrand/all
            string url = string.Format("{0}/api/carbrand/all", WEBUtility.WebApiHost);
            var models = NetUtility.GetHttpWithToken<IList<CarBrand>>(url);
            return models;

        }
        public int AddCarBrand(CarBrand model)
        {
            //POST api/dictype/add
            string url = string.Format("{0}/api/dictype/add", WEBUtility.WebApiHost);
            return NetUtility.PostHttpWithToken(url, model);
        }
        public int EditCarBrand(CarBrand model)
        {
            //POST api/dictype/add
            string url = string.Format("{0}/api/dictype/add", WEBUtility.WebApiHost);
            return NetUtility.PostHttpWithToken(url, model);
        }
        public bool checkNameUnique(string Nname)
        {
            throw new NotImplementedException();
            //return db.CarBrands.Where(m => m.Brand == Nname).Count() > 0;
        }
        public int DeleteCarBrand(string ids)
        {
            //POST api/carbrand/delete?id={id}
            string url = string.Format("{0}/api/carbrand/delete?id={1}", WEBUtility.WebApiHost, ids);
            return NetUtility.PostHttpWithToken(url);

        }


        #region 获取车辆品牌信息
        public CarBrand getCarBrand(string CarGuid)
        {
            //GET api/carbrand/{id}
            string url = string.Format("{0}/api/carbrand/{1}", WEBUtility.WebApiHost, CarGuid);
            var models = NetUtility.GetHttpWithToken<CarBrand>(url);
            return models;
        }
        #endregion

        #region 判断是否必须选择车型
        public bool IsMustSelectModel(int BrandID)
        {
            //var model = (from a in db.CarModels
            //             join b in db.CarSeries on a.SerieID equals b.ID
            //             //join c in db.CarBrands on b.BrandID equals c.ID
            //             where b.BrandID == BrandID
            //             select a.dev_ct).Sum(m=>m);
            //return model > 0;
            throw new NotImplementedException();
        }
        #endregion
    }
}
