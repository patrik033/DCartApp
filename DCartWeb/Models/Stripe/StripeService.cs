using DCartWeb.Models.Carts;
using DCartWeb.Models.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Newtonsoft.Json;
using SendGrid;
using Stripe;
using Stripe.Checkout;
using Stripe.Issuing;
using Stripe.TestHelpers;
using System.Net.Mime;
using CustomerService = Stripe.CustomerService;

namespace DCartWeb.Models.Stripe
{
    public class StripeService : IStripeService
    {

        public StripeService()
        {
            StripeConfiguration.ApiKey = "sk_test_51L17hRG6o6awavjHPuNN2ePMDQHvWCBDr1Gg8OyAiTQSJpB3MttjdANU9nW1G1PzokDPkmDKbZ7EEAPYgIJA49LB00Sdd6uEVT";
        }
        public Session CreateCheckoutSession(Cart items)
        {


            var listOfPictures = new List<string>();
            foreach (var item in items.CartItems)
            {
                listOfPictures.Add(item.PictureUrl);
            }



            var lineItems = new List<SessionLineItemOptions>();
            items.CartItems.ForEach(x => lineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {

                    UnitAmountDecimal = x.Price * 100,
                    Currency = "sek",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = x.Name,


                        Images = new List<string>
                        {
                             "Images/Products/ikea-chair.png"
                        },

                    }
                },
                Quantity = x.QuantityInCart,
            }));



            var customer = new CustomerCreateOptions
            {

                Description = "Test",

                Email = items.UserEmail,
                Address = new AddressOptions
                {
                    City = "Eskilstuna",
                    PostalCode = "1314",
                    Line1 = "Some Address"
                },
                Name = "124",
                Metadata = new Dictionary<string, string>()
                {
                    {
                        "Id","123"
                    }
                },

            };



            var customerService = new CustomerService();
            Customer sessions = new Customer();
            sessions = customerService.Create(customer);

            var options = new SessionCreateOptions
            {

                ShippingAddressCollection = new SessionShippingAddressCollectionOptions
                {
                    AllowedCountries = new List<string>
                    {
                        "SE"
                    },
                },


                PaymentMethodTypes = new List<string>
                {
                    "card",
                },


                LineItems = lineItems,
                BillingAddressCollection = "required",

                Mode = "payment",



                Customer = sessions.Id,
                SuccessUrl = "https://localhost:7177/Stripe/success",
                CancelUrl = "https://localhost:7177/Stripe/failed",


            };




            var service = new SessionService();
            Session session = service.Create(options);


            return session;



        }
    }
}
