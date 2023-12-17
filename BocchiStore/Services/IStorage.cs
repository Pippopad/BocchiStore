using BocchiStore.Models;
using BocchiStore.Pages;
using System.Collections;

namespace BocchiStore.Services
{
    public interface IStorage
    {
        public IEnumerable<BookModel> GetBooks();
        public IEnumerable<BookModel> GetAvailableBooks();
        public IEnumerable<LoanModelFull> GetLoansOnGoing();
        public IEnumerable<LoanModelFull> GetLoansMore15Days();
        public IEnumerable<UserModel> GetUsers();
        public IEnumerable<Top3User> GetTop3Users();
        public IEnumerable<TopBook> GetTopBooks();
        public UserModel? GetUser(int id);
        public IEnumerable<LoanModelFull> GetLoansByUserId(int id);
    }
}
