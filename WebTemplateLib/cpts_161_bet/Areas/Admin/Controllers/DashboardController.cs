using cpts_161_bet.Areas.Admin.Models;
using DataBaseLib.BLL;
using DataBaseLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cpts_161_bet.Areas.Admin.Controllers
{
    public class DashboardController : BaseReportController
    {
        // GET: Admin/Dashboard
        public ActionResult HouseSellingInformation(int page=0) {
            var bll = DataBaseLib.BLL.BLLFactory.Create<I房屋租赁表BL>();
             var query = bll.QueryAll();
            

            HouseReportModel viewModel = new HouseReportModel() {
                ItemList = Pagination(query, page, GetPaginationRouteDict(),
            item => FillHouseInfo(item)),
            };
            return View(viewModel);
        }

        private HouseInformation FillHouseInfo(房屋租赁表 obj, HouseInformation item =null) {
            if (obj == null) {
                return new HouseInformation();
            }
            item = new HouseInformation {
                市区 = obj.市区,
                街道1 = obj.街道1,
                街道2 = obj.街道2,
                小区 = obj.小区,
                室厅厨卫 = string.Format("{0}/{1}/{2}/{3}", obj.室, obj.厅, obj.厨, obj.卫),
                面积 = obj.面积 ?? 0
            };
            return item;
        }


        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            //var dal = new 房屋租赁表_dal();
            //var list = dal.GetAllCityQueryable();
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
