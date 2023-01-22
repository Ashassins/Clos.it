using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Closit.Pages {

    public class ListingModel : PageModel
    {
        private readonly ILogger<ListingModel> _logger;

        public ListingModel(ILogger<ListingModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}