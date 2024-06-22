using AdService.Application.Clients.Queries.GetClients;
using AdService.Application.Dictionaries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdService.UI.Controllers
{
    [Authorize(Roles = $"{RolesDict.Administrator},{RolesDict.Worker}")]
    public class AdminPanelController : BaseController
    {
        public async Task<IActionResult> Clients()
        {
            return View(await Mediator.Send(new GetClientsBasicsQuery()));
        }

        public async Task<IActionResult> EditAdminClient()
        {
            return View(await Mediator.Send(new GetClientsBasicsQuery()));
        }
    }
}
