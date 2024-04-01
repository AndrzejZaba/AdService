using AdService.Application.Clients.Queries.GetClient;
using Microsoft.AspNetCore.Mvc;

namespace AdService.UI.Controllers
{
    public class ClientController : BaseController
    {
        public async Task<IActionResult> Profile()
        {
            return View(await Mediator.Send(new GetClientQuery { UserId = UserId}));
        }
    }
}
