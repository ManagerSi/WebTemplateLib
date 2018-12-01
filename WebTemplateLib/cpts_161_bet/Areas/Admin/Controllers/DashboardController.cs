using cpts_161_bet.Areas.Admin.Models;
using DataBaseLib.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cpts_161_bet.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        public ActionResult HouseSellingInformation() {
            var dal = new 房屋租赁表_dal();
            var list = dal.GetAllCity().Select(i=>new HouseInformation {
                市区 = i.市区,
                街道1 = i.街道1,
                街道2 = i.街道1,
                小区 = i.小区,
                室厅厨卫 = string.Format("{0}/{1}/{2}/{3}", i.室, i.厅, i.厨, i.卫),
                面积 = i.面积 ?? 0
            }).ToList();
            return View(list);
        }

        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            var dal = new 房屋租赁表_dal();
            var list = dal.GetAllCity();
            return View();
        }

        // GET: Admin/Dashboard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Dashboard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Dashboard/Create
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

        // GET: Admin/Dashboard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Dashboard/Edit/5
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

        // GET: Admin/Dashboard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Dashboard/Delete/5
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
