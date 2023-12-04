using BocchiStore.Models;
using System.Collections;

namespace BocchiStore.Services
{
    public interface IStorage
    {
        public IEnumerable<BookModel> GetBooks();
        public IEnumerable<UserModel> GetUsers();
        public IEnumerable<Top3User> GetTop3Users();
        public IEnumerable<TopBook> GetTopBooks();
    }
}
