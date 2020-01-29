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
        public static void InsertFicheToRepeats(int id, string English, string Polish, int CategoryId)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string query = $"INSERT INTO Repeats (Id, English, Polish, CategoryId) Values ('{id}', '{English}', '{Polish}', '{CategoryId}')";
                string query2 = $"SELECT * from Repeats where Id='{id}'";
                var output = cnn.Query<Fiche>(query2, new DynamicParameters());
                var resault = output.ToList();
                if(resault.Count == 0)
                {
                    var affectedRows = cnn.Execute(query);
                }
            }
        }

        public static List<Fiche> LoadFicheRepeats()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string query = $"select * from Repeats";
                var output = cnn.Query<Fiche>(query, new DynamicParameters());
                return output.ToList();
            }
        }

        public static void DeleteFicheFromRepeats(int id)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string query = $"DELETE FROM Repeats WHERE id='{id}'";
                var affectedRows = cnn.Execute(query);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
