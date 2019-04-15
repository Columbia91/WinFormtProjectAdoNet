using FirstProject.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstProject.WinForm
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string dbName = "MyDatabase";
            CreateDatabase(dbName);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        #region Создание базы данных
        public static void CreateDatabase(string dbName)
        {
            MyDatabaseDataService service = new MyDatabaseDataService();

            using (var connection = service._providerFactory.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                try
                {
                    connection.ConnectionString = service._connectionString;
                    connection.Open();

                    command.CommandText = $"Create Database {dbName}";
                    command.ExecuteNonQuery();
                }
                catch (Exception) { }
            }
        }
        #endregion

        #region Подключение к базе данных
        public static bool ConnectionToDatabase()
        {
            SqlConnection connection = new SqlConnection();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.UserID = "sa";
            builder.Password = "123";
            builder.InitialCatalog = "MyDatabase";
            builder.DataSource = "localhost";
            builder.ConnectTimeout = 30;
            connection.ConnectionString = builder.ConnectionString;

            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
        #endregion
    }
}