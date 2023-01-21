using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Closit.Pages;

public class BrowseModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public BrowseModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

