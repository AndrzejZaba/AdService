using AdService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace AdService.UI.Controllers
{
    public class PaymentController : BaseController
    {

        public IActionResult OrderConfirmation()
        {
            var service = new SessionService();
            Session session = service.Get(TempData["Session"].ToString());

            if (session.PaymentStatus.ToLower() == "paid")
                return View("Success");

            return View("Error");
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult CheckOut(string title, string description, decimal price)
        {
            var domain = "https://localhost:7036/";

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "usd",
                            UnitAmountDecimal = price * 100,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = title,
                                Description = description
                            }
                        },
                        Quantity = 1
                    }

                },
                Mode = "payment",
                CustomerEmail = UserEmail,
                SuccessUrl = domain + $"Payment/OrderConfirmation",
                CancelUrl = domain + $"Payment/Error"
            };

            var service = new SessionService();
            Session session = service.Create(options);

            TempData["Session"] = session.Id;

            Response.Headers.Add("Location", session.Url);


            return new StatusCodeResult(303);
        }

    }
}
