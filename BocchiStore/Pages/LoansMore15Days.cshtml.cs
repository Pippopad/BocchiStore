using BocchiStore.Models;
using BocchiStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BocchiStore.Pages
{
    public class LoansMore15DaysModel : PageModel
    {
        private readonly IStorage _storage;

        public LoansMore15DaysModel(IStorage storage)
        {
            _storage = storage;
        }

        public void OnGet()
        {
        }

        public List<LoanModelFull> Loans => _storage.GetLoansMore15Days().ToList();
    }
}
