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

    public partial interface IBASE_USER_dal :
    DataBaseLib.Infrastructure.DAL.IRepository<BASE_USER> {

    }


    public class BASE_USER_dal :
       DataBaseLib.Infrastructure.DAL.GenericRepository<BASE_USER>,
       DataBaseLib.DAL.IBASE_USER_dal {

        private DataBaseLib.Model.ManagerSiContext context { get { return this.UnitOfWork.Context; } }
        private DataBaseLib.DAL.UnitOfWork UnitOfWork { get; set; }
        public BASE_USER_dal(DAL.UnitOfWork unitOfWork) : base (unitOfWork)
      {
            this.UnitOfWork = unitOfWork;
        }




        /// <summary>
        /// LINQ Method syntax
        /// </summary>
        /// <returns></returns>
        public BASE_USER GetByAccount(string name,string pwd) {             
            using(var context = new ManagerSiContext()) {
                var list = context.BASE_USER.Where(i => i.State == "1" && i.UserAccount == name && i.UserPWD == pwd).FirstOrDefault();
                return list;
            }
        }
        /// <summary>
        /// LINQ Query syntax
        /// </summary>
        /// <returns></returns>
        public List<BASE_USER> GetAllCityByLINQQuery() {
            var query = dbSet;
            return query.Where(i => i.State == "1").OrderByDescending(i => i.ID).ToList();
        }
       
    }
}
