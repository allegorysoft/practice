using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Allegory.NgSampleModule.Pages;

public class IndexModel : NgSampleModulePageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
