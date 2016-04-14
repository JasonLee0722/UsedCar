using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsedCar.ViewModels;

namespace Service.Abstract
{
    public interface ICarBrandService
    {
        CarBrand getCarBrandDetail(int id);
        CarBrand getCarBrandDetail(string Brand);
        IPagedList<CarBrand> GetCarBrandList(int PageSize, int PageIndex);
        IList<CarBrand> GetCarBrandList();
        int AddCarBrand(CarBrand model);
        int EditCarBrand(CarBrand model);
        bool checkNameUnique(string Nname);
        int DeleteCarBrand(string ids);
        /// <summary>
        /// 获取车辆品牌信息
        /// </summary>
        /// <param name="CarGuid"></param>
        /// <returns></returns>
        CarBrand getCarBrand(string CarGuid);

        #region 判断是否必须选择车型
        /// <summary>
        /// 判断是否必须选择车型
        /// </summary>
        /// <param name="BrandID"></param>
        /// <returns></returns>
        bool IsMustSelectModel(int BrandID);
        #endregion
    }
}
