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
    public class 房屋租赁表_dal {
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
    }
}
