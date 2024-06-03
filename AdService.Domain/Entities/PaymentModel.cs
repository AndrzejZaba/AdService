

namespace AdService.Domain.Entities;

public class PaymentModel
{
    public string StripeToken { get; set; }
    public decimal Amount { get; set; }
}
