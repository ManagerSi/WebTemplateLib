using cpts_161_bet.Areas.Admin.Models;
using DataBaseLib.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Mvc.Filters;

namespace cpts_161_bet.Areas.Admin.Controllers
{
    public class BaseReportController : Controller
    {
     
        public BaseReportModel<Q> MyPaging<T,Q>(IQueryable<T> source,int CurrentPageIndex, Func<T, Q> selectFunc) {
            var model = new BaseReportModel<Q>();
            model.TotalCount = source.Count();
            model.CurrentPageIndex = CurrentPageIndex;
            model.PageCount = model.TotalCount / model.OnePageCount + (model.TotalCount % model.OnePageCount > 0 ? 1 : 0);

            model.ItemList = source.Skip(model.CurrentPageIndex * model.OnePageCount).Take(model.PageCount).Select(selectFunc).AsEnumerable();
            return model;
        }

        protected PaginationModel<T> Pagination<T>(IEnumerable<T> list, int pageNumber, RouteValueDictionary routeDict) where T : class {
            return Pagination(list, pageNumber, routeDict, item => item);
        }
        /// <summary>
        /// 用于分页
        /// </summary>
        /// <typeparam name="I"></typeparam>
        /// <typeparam name="O"></typeparam>
        /// <param name="list"></param>
        /// <param name="pageNumber"></param>
        /// <param name="routeDict">需要传递的参数</param>
        /// <param name="selectFunc">映射函数</param>
        /// <returns></returns>
        protected PaginationModel<O> Pagination<I, O>(
            IEnumerable<I> list, int pageNumber,
            RouteValueDictionary routeDict, Func<I, O> selectFunc)
          where I : class
          where O : class {
            IQueryable<I> qlist = list.AsQueryable();
            PaginationModel<O> pagination = new PaginationModel<O>();
            // TODO（Moore）使用一个分页控件
            //HttpContext.Trace.Write("a");
            pagination.CurrentPage = pageNumber;
            pagination.ItemCount = qlist.Count();
            //HttpContext.Trace.Write("b");
            pagination.PageCount = pagination.ItemCount / Configuration.WapPageSize +
              (pagination.ItemCount % Configuration.WapPageSize == 0 ? 0 : 1);
            pagination.SubItemList =
              qlist.Skip(pageNumber * Configuration.WapPageSize)
              .Take(Configuration.WapPageSize)
              .Select(selectFunc).ToList();
            //HttpContext.Trace.Write("b2");

            pagination.routeDict = RouteData == null ? new RouteValueDictionary() : new RouteValueDictionary(RouteData.Values);
            pagination.routeDict.Add("page", pageNumber);
            if (null != routeDict) {
                pagination.routeDict.UpdateWith(routeDict);
            }
            //HttpContext.Trace.Write("c");
            return pagination;
        }

        protected PaginationModel<T> Pagination<T>(IEnumerable<T> list, int pageNumber) where T : class {
            return Pagination(
              list, pageNumber,
              null);
        }


        protected RouteValueDictionary GetPaginationRouteDict() {
            return new RouteValueDictionary();
            //return new RouteValueDictionary(RouteData.Values);
        }
        protected RouteValueDictionary GetPaginationRouteDict(object obj) {
            return obj.ToRouteDict();
        }

        protected string RenderPartialViewToString(string viewName, object model) {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter()) {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                if (null == viewResult.View) {
                    throw new FileNotFoundException();
                }
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

        //protected TSICIdentity GetTSICIdentity() {
        //    if (null != User) {
        //        return User.Identity as TSICIdentity;
        //    }
        //    // api calling
        //    var user = System.Threading.Thread.CurrentPrincipal as TSICPrincipal;
        //    if (user == null) {
        //        return null;
        //    }
        //    return user.Identity as TSICIdentity;
        //}

        //protected string GetLogPrefix() {
        //    var i = GetTSICIdentity();
        //    string prefix = "(";
        //    if (null != i.BaseEmployee) {
        //        prefix += i.BaseEmployee.ID.ToString();
        //    }
        //    prefix += ") - ";
        //    return prefix + Request.UserHostAddress + " - ";
        //}
        //protected string _L(string actionName, params string[] msgs) {
        //    return GetLogPrefix() + actionName + " " + string.Join(" ", msgs);
        //}

        // rewrite download files
        /// <summary>
        /// fileContent 是zip File的内容
        /// 如果文件过大，会将文件写入磁盘再下载
        /// </summary>
        /// <param name="fileContent"></param>
        /// <param name="contentType"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public ActionResult ZippedFile(byte[] fileContent, string contentType, string fileName = null) {

            if (fileContent.Length < 300 * 1024) {
                return File(fileContent, contentType);
            }
            // save into temp File
            Response.ClearHeaders();
            if (fileName == null) {
                fileName = DateTime.Now.Ticks.ToString() + ".zip";
            }
            var vPath = System.Configuration.ConfigurationManager.AppSettings["/zipfile"];
            var filePath = Server.MapPath(vPath);

            if (!System.IO.Directory.Exists(filePath)) {
                System.IO.Directory.CreateDirectory(filePath);
            }

            System.IO.File.WriteAllBytes(filePath + fileName, fileContent);

            return Redirect(vPath + fileName);
        }




    }
}