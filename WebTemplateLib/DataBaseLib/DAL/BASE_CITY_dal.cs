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
    public class BASE_CITY_dal {
        /// <summary>
        /// LINQ Method syntax
        /// </summary>
        /// <returns></returns>
        public List<BASE_CITY> GetAllCity() {             
            using(var context = new ManagerSiContext()) {
                var list = context.BASE_CITY.Where(i => i.STATE == "1").ToList();
                return list;
            }
        }
        /// <summary>
        /// LINQ Query syntax
        /// </summary>
        /// <returns></returns>
        public List<BASE_CITY> GetAllCityByLINQQuery() {
            using (var context = new ManagerSiContext()) {
                var L2EQuery = from st in context.BASE_CITY
                               where st.STATE == "1" select st;
                var list = L2EQuery.ToList();
                return list;
            }
        }
        /// <summary>
        /// Entity SQL
        /// </summary>
        /// <returns></returns>
        public List<BASE_CITY> GetAllCityBySQL() {
            using (var context = new ManagerSiContext()) {
                //Querying with Object Services and Entity SQL
                string sqlString = "SELECT VALUE st FROM ManagerSiContext.BASE_CITY " +
                "AS st WHERE st.STATE == '1'";
                var objctx = (context as System.Data.Entity.Infrastructure.IObjectContextAdapter).ObjectContext;
                ObjectQuery<BASE_CITY> student = objctx.CreateQuery<BASE_CITY>(sqlString);
                //BASE_CITY newStudent = student.First<BASE_CITY>();
                return student.ToList();
            }
        }
        /// <summary>
        /// EntityDataReader
        /// </summary>
        /// <returns></returns>
        public Dictionary<int,string> GetAllCityByEntityDataReader() {
            using (var con = new EntityConnection("name=ManagerSiContext")) {
                con.Open();
                EntityCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT VALUE st FROM ManagerSiContext.BASE_CITY as st WHERE st.STATE == '1'";
                Dictionary<int, string> dict = new Dictionary<int, string>();

                using (EntityDataReader rdr = cmd.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.CloseConnection)) {
                    while (rdr.Read()) {
                        int a = rdr.GetInt32(0);
                        var b = rdr.GetString(1);
                        dict.Add(a, b);
                    }
                }
                return dict;
            }
        }
        /// <summary>
        /// Native SQL
        /// </summary>
        /// <returns></returns>
        public List<BASE_CITY> GetAllCityByNativeSQL() {
            using (var context = new ManagerSiContext()) {
                var list = context.BASE_CITY.SqlQuery("Select * from BASE_CITY where STATE == '1'").ToList();
                return list;
            }
        }
        /// <summary>
        /// SQL
        /// </summary>
        /// <returns></returns>
        public int UpdateCityBySQL() {
            using (var context = new ManagerSiContext()) {
                var num = context.Database.ExecuteSqlCommand("Update BASE_CITY set STATE = '1' where id = 1");
                return num;
            }
        }
    }
}
