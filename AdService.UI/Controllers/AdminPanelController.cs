using AdService.Application.Clients.Queries.GetClients;
using AdService.Application.Clients.Queries.GetEditAdminClient;
using AdService.Application.Dictionaries;
using AdService.Application.Users.Commands.DeleteUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdService.UI.Controllers
{
    [Authorize(Roles = $"{RolesDict.Administrator},{RolesDict.Worker}")]
    public class AdminPanelController : BaseController
    {
        private readonly ILogger<AdminPanelController> _logger;

        public AdminPanelController(ILogger<AdminPanelController> logger)
        {
            _logger = logger;
        }
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

            TempData["Success"] = "Customer data has been updated.";

            return RedirectToAction("Clients");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            try
            {
                await Mediator.Send(
                    new DeleteUserCommand
                    {
                        Id = userId
                    });
                return Json(new { success = true });
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, null);
                return Json(new { success = false });
            }
        }
    }
}
