using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Closit.Pages {

    public class RacingShirtListingModel : PageModel
    {
        private readonly ILogger<RacingShirtListingModel> _logger;

        public RacingShirtListingModel(ILogger<RacingShirtListingModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}