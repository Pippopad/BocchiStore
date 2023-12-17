using BocchiStore.Models;
using BocchiStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BocchiStore.Pages
{
    public class LoansOnGoingModel : PageModel
    {
        private readonly IStorage _storage;

        public LoansOnGoingModel(IStorage storage)
        {
            _storage = storage;
        }

        public void OnGet()
        {
        }

        public List<LoanModelFull> Loans => _storage.GetLoansOnGoing().ToList();
    }
}
