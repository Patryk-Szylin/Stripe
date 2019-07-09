using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


public class Data
{
    public string Sid { get; set; }
}

namespace Stripe.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //StripeConfiguration.ApiKey = "sk_test_l5D3Gu5k6G00kaRnmy3deczM00zBvQf5OO";
            //var options = new ChargeCreateOptions
            //{
            //    Amount = 999,
            //    Currency = "usd",
            //    Source = "tok_visa",
            //    ReceiptEmail = "jenny.rosen@example.com",
            //};

            //var service = new ChargeService();
            //Charge charge = service.Create(options);
            //Console.WriteLine(charge);
            StripeConfiguration.ApiKey = "sk_test_l5D3Gu5k6G00kaRnmy3deczM00zBvQf5OO";

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> {
        "card",
    },
                LineItems = new List<SessionLineItemOptions> {
        new SessionLineItemOptions {
            Name = "T-shirt",
            Description = "Comfortable cotton t-shirt",
            Amount = 500,
            Currency = "gbp",
            Quantity = 1,
        },
    },
                SuccessUrl = "https://example.com/success",
                CancelUrl = "https://example.com/cancel",
            };

            var service = new SessionService();
            Session session = service.Create(options);
            return View("Index.cshtml", new Data { Sid = session.Id });
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}