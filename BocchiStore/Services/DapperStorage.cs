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

        public IEnumerable<BookModel> GetAvailableBooks()
        {
            return _connection.Query<BookModel>("SELECT * FROM Books WHERE Books.BookId NOT IN (SELECT b.BookId FROM Books b INNER JOIN Loans ON Books.BookId = Loans.BookId WHERE Loans.EndDate IS NULL)");
        }

        public IEnumerable<LoanModelFull> GetLoansOnGoing()
        {
            var query = _connection.Query<LoanModel>("SELECT * FROM Loans WHERE EndDate IS NULL");

            List<LoanModelFull> loans = new List<LoanModelFull>();
            foreach (var q in query)
                loans.Add(new LoanModelFull()
                {
                    StartDate = q.StartDate,
                    User = _connection.Query<UserModel>("SELECT * FROM Users WHERE Users.UserId=" + q.UserId).First(),
                    Book = _connection.Query<BookModel>("SELECT * FROM Books WHERE Books.BookId=" + q.BookId).First(),
                });

            return loans;
        }

        public IEnumerable<LoanModelFull> GetLoansMore15Days()
        {
            var query = _connection.Query<LoanModel>("SELECT * FROM Loans WHERE (EndDate IS NULL AND DATEDIFF(DAY, StartDate, GETDATE()) > 15) OR (EndDate IS NOT NULL AND DATEDIFF(DAY, StartDate, EndDate) > 15)");

            List<LoanModelFull> loans = new List<LoanModelFull>();
            foreach (var q in query)
                loans.Add(new LoanModelFull()
                {
                    StartDate = q.StartDate,
                    EndDate = q.EndDate,
                    User = _connection.Query<UserModel>("SELECT * FROM Users WHERE Users.UserId=" + q.UserId).First(),
                    Book = _connection.Query<BookModel>("SELECT * FROM Books WHERE Books.BookId=" + q.BookId).First(),
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

		public UserModel? GetUser(int id)
        {
            return _connection.Query<UserModel>("SELECT * FROM Users WHERE UserId=" + id).SingleOrDefault();
		}

		public IEnumerable<LoanModelFull> GetLoansByUserId(int id)
        {
			var query = _connection.Query<LoanModel>("SELECT * FROM Loans WHERE UserId=" + id + " ORDER BY StartDate DESC");

			List<LoanModelFull> loans = new List<LoanModelFull>();
			foreach (var q in query)
				loans.Add(new LoanModelFull()
				{
					StartDate = q.StartDate,
					EndDate = q.EndDate,
					User = _connection.Query<UserModel>("SELECT * FROM Users WHERE Users.UserId=" + q.UserId).First(),
					Book = _connection.Query<BookModel>("SELECT * FROM Books WHERE Books.BookId=" + q.BookId).First(),
				});

			return loans;
		}
	}
}
