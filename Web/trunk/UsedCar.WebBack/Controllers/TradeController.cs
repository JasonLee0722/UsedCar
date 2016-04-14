using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UsedCar.WebBack.Controllers
{

    [ValidateUserLogin]
    public class TradeController : Controller
    {
        // GET: Trade
        public ActionResult Index()
        {
            return View();
        }

        // GET: Trade/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Trade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trade/Create
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

        // GET: Trade/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Trade/Edit/5
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

        // GET: Trade/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Trade/Delete/5
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
