using AdService.Application.Clients.Queries.GetClients;
using AdService.Application.Clients.Queries.GetEditAdminClient;
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

        public async Task<IActionResult> EditAdminClient(string clientId)
        {
            return View(await Mediator.Send(new GetEditAdminClientQuery { UserId = clientId }));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAdminClient(EditAdminClientVm vm)
        {
            var result = await MediatorSendValidate(vm.Client);

            if (!result.IsValid)
                return View(vm);

            TempData["Success"] = "Dane o klientach zostały zaktualizowane.";

            return RedirectToAction("Clients");
        }
    }
}
