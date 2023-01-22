using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Closit.Pages {

    public class CargoPantsListingModel : PageModel
    {
        private readonly ILogger<CargoPantsListingModel> _logger;

        public CargoPantsListingModel(ILogger<CargoPantsListingModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}