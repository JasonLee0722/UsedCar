using Common.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsedCar.ViewModels;

namespace UsedCar.WebBack.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            //return RedirectToAction("Index", "Home");
            string loginName = collection["UserName"];
            string pwd = collection["pwd"];

            string url = string.Format("{0}/api/user/login?loginName={1}&loginPwd={2}", WEBUtility.WebApiHost, loginName, pwd);

            dynamic json = NetUtility.GetPostResponse(url);
            if (json.State)
            {
                if (!string.IsNullOrEmpty(json.Content))
                {
                    var user = JsonConvert.DeserializeObject<SysUser>(json.Content);
                    //var user = JsonConvert.DeserializeObject(json.Content);
                    if (user != null)
                    {
                        user.LoginPwd = pwd;
                        Session[WEBUtility.UserSessionName()] = user;
                        return RedirectToAction("Index", "Home");
                    }
                }
                return View((object)"用户名或密码错误");
            }

            return View((object)json.Content);
        }
        // GET: Login/LoginOut
        public ActionResult LoginOut()
        {
            Session[WEBUtility.UserSessionName()] = null;
            return RedirectToAction("Index");
        }
        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
