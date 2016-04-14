using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Transactions;
using System.Web;
using System.Web.Http;

using UsedCar.Domain;

namespace UsedCar.WebAPIs.Controllers
{
    /// <summary>
    /// 二手车信息
    /// </summary>
    [Authorize]
    [RoutePrefix("api/car")]
    public class CarController : ApiController
    {
        private int m_pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["page:size"]);

        private CarRepository m_carRepo = new CarRepository();
        private BasicParmRepository m_basicRepo = new BasicParmRepository();

        /// <summary>
        /// 查询所有车辆信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        [AllowAnonymous]
        public IHttpActionResult CarsOfPage(int pageIndex, Dictionary<string, string> terms)
        {
            //var user = HttpContext.Current.User.Identity;
            //Uri expectedRootUri = new Uri(context.Request.Uri, "/");
            //if (expectedRootUri.AbsoluteUri == context.RedirectUri)
            //{
            //    context.Validated();
            //}
            //return Task.FromResult<object>(null);

            //return m_db.Cars;

            var cars = m_carRepo.GetCarsOfPage(pageIndex, m_pageSize, terms);

            return Ok(cars);
        }

        /// <summary>
        /// 添加车辆基本信息（身份验证）
        /// </summary>
        /// <param name="obj">Car</param>
        /// <returns>Car.GUID</returns>
        [HttpPost]
        [Route("add")]
        public IHttpActionResult AddCarInfo(Car obj)
        {
            obj.GUID = Guid.NewGuid().ToString();
            var car = m_carRepo.AddCar(obj);
            if (null == car)
                return BadRequest();
            else
            {
                return Ok(new {Message = car.GUID});
            }
        }
            
        /// <summary>
        /// 添加车辆基础参数（身份验证）
        /// </summary>
        /// <param name="car_guid">Car.GUID</param>
        /// <param name="obj">BasicParm</param>
        /// <returns>Basic.GUID</returns>
        [HttpPost]
        [Route("basic/add")]
        public IHttpActionResult AddBasicWithCarGUID(string car_guid, BasicParm obj)
        {
            var car = m_carRepo.GetCarForGUID(car_guid);
            if (null == car)
            {
                return BadRequest();
            }
            else
            {
                using (TransactionScope trans = new TransactionScope())
                {
                    var basicParm = m_basicRepo.AddBasicParm(obj);
                    car.Basic = basicParm.GUID;
                    m_carRepo.ModifyCarWithObject(car);

                    trans.Complete();
                }
                return Ok(new { Message = car.Basic });
            }
        }
    }
}
