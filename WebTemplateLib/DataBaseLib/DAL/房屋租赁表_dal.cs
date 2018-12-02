using DataBaseLib.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLib.DAL {



    public partial interface I房屋租赁表_dal :
    DataBaseLib.Infrastructure.DAL.IRepository<房屋租赁表> {
        IQueryable<房屋租赁表> GetAllCityQueryable();
    }


    public class 房屋租赁表_dal :
       DataBaseLib.Infrastructure.DAL.GenericRepository<房屋租赁表>,
       DataBaseLib.DAL.I房屋租赁表_dal {

        private DataBaseLib.Model.ManagerSiContext context { get { return this.UnitOfWork.Context; } }
        private DataBaseLib.DAL.UnitOfWork UnitOfWork { get; set; }
        public 房屋租赁表_dal(DAL.UnitOfWork unitOfWork) : base(unitOfWork) {
            this.UnitOfWork = unitOfWork;
        }
//////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////


        /// <summary>
        /// LINQ Method syntax
        /// </summary>
        /// <returns></returns>
        public List<房屋租赁表> GetAllCity() {             
            using(var context = new ManagerSiContext()) {
                var list = context.房屋租赁表.Where(i => i.State == "1").ToList();
                return list;
            }
        }
        public IQueryable<房屋租赁表> GetAllCityQueryable() {
            var query = dbSet;
            return query.Where(i => i.State == "1").OrderByDescending(i=>i.ID);
            //using (var context = new ManagerSiContext()) {
            //    var list = context.房屋租赁表.Where(i => i.State == "1");
            //    return list;
            //}
        }
    }
}
