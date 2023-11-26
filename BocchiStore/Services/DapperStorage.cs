using BocchiStore.Models;
using Dapper;
using System.Data.SqlClient;

namespace BocchiStore.Services
{
    public class DapperStorage : IStorage
    {
        private readonly SqlConnection _connection;

        public DapperStorage()
        {
            _connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BocchiStore;Integrated Security=True;Connect Timeout=30;Encrypt=False");
        }

        public IEnumerable<BookModel> GetBooks()
        {
            return _connection.Query<BookModel>("SELECT * FROM Books");
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return _connection.Query<UserModel>("SELECT * FROM Users");
        }
    }
}
