using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsedCar.ViewModels;

namespace Service.Abstract
{
    public interface ICarSerieService
    {
        CarSerie getCarSerieDetail(int id);
        CarSerie getCarSerieDetail(string serie);
        IPagedList<CarSerie> GetCarSerieList(int PageSize, int PageIndex, int CarBrandId);
        IList<CarSerie> GetCarSerieList(int CarBrandId);
        int AddCarSerie(CarSerie model);
        int EditCarSerie(CarSerie model);
        bool checkNameUnique(string Nname);
        int DeleteCarSerie(string id);
    }
}
