using System.Configuration;
using System.Data.Common;

namespace FirstProject.DataAccess
{
    public class MyDatabaseDataService
    {
        public readonly string _connectionString;
        public readonly string _providerName;
        public readonly DbProviderFactory _providerFactory;
        public MyDatabaseDataService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _providerName = ConfigurationManager.ConnectionStrings["DefaultConnection"].ProviderName;
            _providerFactory = DbProviderFactories.GetFactory(_providerName);
        }
    }
}