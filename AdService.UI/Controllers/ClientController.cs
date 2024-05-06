using AdService.Application.Clients.Commands.EditUser;
using AdService.Application.Clients.Queries.GetClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AdService.UI.Controllers
{
    [Authorize]
    public class ClientController : BaseController
    {
        public async Task<IActionResult> Profile()
        {
            return View(await Mediator.Send(new GetClientQuery { UserId = UserId}));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(EditUserCommand command)
        {
            var result = await MediatorSendValidate(command);

            if (!result.IsValid)
                return View(command);

            TempData["Success"] = "Your data has beed successfully updated.";

            return RedirectToAction("Profile");
        }


    }
}
