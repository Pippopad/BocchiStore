using BocchiStore.Models;
using BocchiStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BocchiStore.Pages
{
    public class ViewUserModel : PageModel
    {
        private readonly IStorage _storage;

        public ViewUserModel(IStorage storage)
        {
            _storage = storage;
        }

        public void OnGet(int id)
        {
			SelectedUser = _storage.GetUser(id);
            Loans = _storage.GetLoansByUserId(id).ToList();
        }

        public UserModel SelectedUser;
        public List<LoanModelFull> Loans;
    }
}
