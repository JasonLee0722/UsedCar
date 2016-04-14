using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsedCar.ViewModels;

namespace Service.Abstract
{
    public interface ICarModelService
    {
        CarModel getCarModelDetail(int id);
        CarModel getCarModelDetail(string Name);
        IPagedList<CarModel> GetCarModelList(int PageSize, int PageIndex);
        IList<CarModel> GetCarModelList(int CarSerieID);
        IPagedList<CarModel> GetCarModelList(int PageSize, int PageIndex, int CarSerieId);
        int AddCarModel(CarModel CarModel);
        int EditCarModel(CarModel CarModel);
        bool checkNameUnique(string Nname);
        int DeleteCarModel(string ids);
    }
}
