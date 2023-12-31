using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Allegory.StockManagement.Pages;

public class IndexModel : StockManagementPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
