using BocchiStore.Models;
using BocchiStore.Pages;
using System.Collections;

namespace BocchiStore.Services
{
    public interface IStorage
    {
        public IEnumerable<BookModel> GetBooks();
        public IEnumerable<LoanOnGoingModel> GetLoansOnGoing();
        public IEnumerable<UserModel> GetUsers();
        public IEnumerable<Top3User> GetTop3Users();
        public IEnumerable<TopBook> GetTopBooks();
    }
}
