using DCartWeb.Models.Carts;
using Stripe.Checkout;

namespace DCartWeb.Models.Stripe
{
    public interface IStripeService
    {
        Session CreateCheckoutSession(Cart items);
    }
}
