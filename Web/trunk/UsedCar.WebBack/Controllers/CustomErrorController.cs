using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UsedCar.WebBack.Controllers
{
    public class CustomErrorController : Controller
    {
        //
        // GET: /CustomError/
        /// <summary>
        /// 目标未发现错误--404
        /// </summary>
        /// <returns></returns>
        public ActionResult NotFound()
        {
            return View("Error");
        }
        /// <summary>
        /// 内部服务器错误--500
        /// </summary>
        /// <returns></returns>
        public ActionResult InternalError()
        {
            return View("Error");
        }

    }
}