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

        public IEnumerable<LoanOnGoingModel> GetLoansOnGoing()
        {
            var query = _connection.Query<LoanModel>("SELECT * FROM Loans WHERE EndDate IS NULL");

            List<LoanOnGoingModel> loans = new List<LoanOnGoingModel>();
            foreach (var q in query) loans.Add(new LoanOnGoingModel()
            {
                StartDate = q.StartDate,
                User = _connection.Query<UserModel>("SELECT * FROM Users WHERE UserIf").First(),
                Book = _connection.Query<BookModel>("SELECT * ").First(),
            });

            return loans;
        }

        public IEnumerable<Top3User> GetTop3Users()
        {
            var _top3Users = _connection.Query<Top3User>("SELECT TOP 3 Loans.UserId, COUNT(DISTINCT Loans.BookId) AS 'BookCount' FROM Loans GROUP BY Loans.UserId ORDER BY BookCount DESC").ToList();
            List<Top3User> top3Users = new List<Top3User>();
            foreach (var t3u in _top3Users)
                top3Users.Add(new Top3User()
                {
                    UserId = t3u.UserId,
                    BookCount = t3u.BookCount,
                    User = _connection.Query<UserModel>($"SELECT * FROM Users WHERE Users.UserId={t3u.UserId}").First()
                });
            return top3Users;
        }

        public IEnumerable<TopBook> GetTopBooks()
        {
            var _topBooks = _connection.Query<TopBook>("SELECT Loans.BookId, COUNT(Loans.BookId) AS 'Loans' FROM Loans GROUP BY Loans.BookId ORDER BY Loans DESC").ToList();
            List<TopBook> topBooks = new List<TopBook>();
            foreach (var tb in _topBooks)
                topBooks.Add(new TopBook()
                {
                    BookId = tb.BookId,
                    Loans = tb.Loans,
                    Book = _connection.Query<BookModel>($"SELECT * FROM Books WHERE Books.BookId={tb.BookId}").First()
                });
            return topBooks;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return _connection.Query<UserModel>("SELECT * FROM Users");
        }
    }
}
