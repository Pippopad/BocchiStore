using System.Data.SqlClient;

namespace BocchiStore.Services
{
    public class DapperStorage : IStorage
    {
        private readonly SqlConnection _connection;

        public DapperStorage()
        {
            _connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BocchiStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
