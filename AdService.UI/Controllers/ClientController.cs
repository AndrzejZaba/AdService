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

        public IActionResult EditProfile()
        {
            return View();
            //return View(await Mediator.Send(new GetEditClientQuery { UserId = UserId }));
        }
    }
}
