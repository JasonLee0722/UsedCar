using Common.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsedCar.WebBack;
using UsedCar.ViewModels;

namespace UsedCar.WebBack.Controllers
{
    [ValidateUserLogin]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            string url = string.Format("{0}/api/user/all", WEBUtility.WebApiHost);
            var _token = NetUtility.GetAccessTokenFromCache();
            dynamic json = NetUtility.GetHttp(url, token: _token);
            if (json.State)
            {
                if (!string.IsNullOrEmpty(json.Content))
                {
                    var users = JsonConvert.DeserializeObject<IList<SysUser>>(json.Content);
                    //var user = JsonConvert.DeserializeObject(json.Content);
                    if (users != null)
                    {
                        return View(users);
                    }
                }
            }
            return View(new List<SysUser>());
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            //api/user/{id}
            string url = string.Format("{0}/api/user/{1}", WEBUtility.WebApiHost, id);
            var _token = NetUtility.GetAccessTokenFromCache();
            dynamic json = NetUtility.GetPostResponse(url, token: _token);
            if (json.State)
            {
                if (!string.IsNullOrEmpty(json.Content))
                {
                    var user = JsonConvert.DeserializeObject<SysUser>(json.Content);
                    //var user = JsonConvert.DeserializeObject(json.Content);
                    if (user != null)
                    {
                        return View(user);
                    }
                }
            }
            return View(new SysUser());
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
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

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            //api/user/{id}
            string url = string.Format("{0}/api/user/{1}", WEBUtility.WebApiHost, id);

            dynamic json = NetUtility.GetPostResponse(url);
            if (json.State)
            {
                if (!string.IsNullOrEmpty(json.Content))
                {
                    var user = JsonConvert.DeserializeObject<SysUser>(json.Content);
                    //var user = JsonConvert.DeserializeObject(json.Content);
                    if (user != null)
                    {
                        return View(user);
                    }
                }
            }
            return View(new SysUser());
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
