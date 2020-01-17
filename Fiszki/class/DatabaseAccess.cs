using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiszki
{
    public class DatabaseAccess
    {
        public static List<Category> LoadCategorys()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string query = $"select * from Category";
                var output = cnn.Query<Category>(query, new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<int> GetCategoryId(string categoryName)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string query = $"select Id from Category where Nazwa='{categoryName}'";
                var output = cnn.Query<int>(query, new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<Fiche> LoadFiche(int categoryId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string query = $"select * from Fiche where CategoryId='{categoryId}'";
                var output = cnn.Query<Fiche>(query, new DynamicParameters());
                return output.ToList();
            }
        }


        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
