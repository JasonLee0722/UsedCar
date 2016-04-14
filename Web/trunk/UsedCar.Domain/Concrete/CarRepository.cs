using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.Entity;

namespace UsedCar.Domain
{
    public class CarRepository
    {
        private EFDbContext m_db = new EFDbContext();

        /// <summary>
        /// 查询车辆基本信息
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页行</param>
        /// <param name="terms">搜索条件</param>
        /// <returns></returns>
        public IQueryable<Car> GetCarsOfPage(int pageIndex, int pageSize, Dictionary<string, string> terms)
        {
            var query = from cars in m_db.Cars
                        select cars;
            if (null != terms)
            {
                if (terms["brand"] != string.Empty)
                {
                    //品牌
                    query = query.Where(q => q.Brand == terms["brand"]);
                }
                if (terms["series"] != string.Empty)
                {
                    //车系
                    query = query.Where(q => q.Series == terms["series"]);
                }
                if (terms["minPrice"] != string.Empty && terms["maxPrice"] != string.Empty)
                {
                    //价格
                    decimal minPrice = Convert.ToDecimal(terms["minPrice"]);
                    decimal maxPrice = Convert.ToDecimal(terms["maxPrice"]);
                    query = query.Where(q => q.Price >= minPrice && q.Price <= maxPrice);
                }
                if (terms["age"] != string.Empty)
                {
                    //车龄
                    int age = Convert.ToInt32(terms["age"]);
                    DateTime nowTime = DateTime.Now;

                    //日期比较可用DateDiffDay、Subtract
                    query = query.Where(q => q.IssueDate.AddYears(age).Year == nowTime.Year && q.IssueDate.Month >= nowTime.Month);
                }
                if (terms["model"] != string.Empty)
                {
                    //车型
                    query = query.Where(q => q.Model == terms["model"]);
                }
                if (terms["mileage"] != string.Empty)
                {
                    //里程
                    float mileage = Convert.ToSingle(terms["mileage"]);
                    query = query.Where(q => q.Mileage <= mileage);
                }
                if (terms["gearBox"] != string.Empty)
                {
                    //变速箱
                    query = query.Where(q => q.GearBox == terms["gearBox"]);
                }
                if (terms["ES"] != string.Empty)
                {
                    //排放标准
                    query = query.Where(q => q.ES == terms["es"]);
                }
                if (terms["minCC"] != string.Empty && terms["maxCC"] != string.Empty)
                {
                    //排量
                    float minCC = Convert.ToSingle(terms["minCC"]);
                    float maxCC = Convert.ToSingle(terms["maxCC"]);

                    query = query.Where(q => q.CC >= minCC && q.CC <= maxCC);
                }
                if (terms["color"] != string.Empty)
                {
                    //车身颜色
                    query = query.Where(q => q.Color == terms["color"]);
                }
                if (terms["made"] != string.Empty)
                {
                    query = query.Where(q => q.Made == terms["made"]);
                }
            }
            query.OrderByDescending(q => q.AddTime)
                .Take(pageSize * pageIndex)
                .Skip(pageSize * (pageIndex - 1))
                .AsQueryable();
            return null;
        }

        /// <summary>
        /// 添加车辆基本信息(还要添加详细信息)
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public Car AddCar(Car car)
        {
            m_db.Cars.Add(car);
            m_db.SaveChanges();
            return car;
        }

        /// <summary>
        /// 查询车辆基本信息，条件：GUID
        /// </summary>
        /// <returns>The car for GUI.</returns>
        /// <param name="guid">GUID.</param>
        public Car GetCarForGUID(string guid)
        {
            var query = (from q in m_db.Cars
                                  where q.GUID == guid
                                  select q)
                .FirstOrDefault();
            return query;
        }

        /// <summary>
        /// 修改车辆基本信息
        /// </summary>
        /// <returns></returns>
        /// <param name="car">Car.</param>
        public bool ModifyCarWithObject(Car car)
        {
            m_db.Entry(car).State = EntityState.Modified;
            int rows = m_db.SaveChanges();
            if (rows > 0)
                return true;
            else
                return false;
        }
    }
}
