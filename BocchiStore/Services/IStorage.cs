using BocchiStore.Models;
using System.Collections;

namespace BocchiStore.Services
{
    public interface IStorage
    {
        public IEnumerable<BookModel> GetBooks();
    }
}
