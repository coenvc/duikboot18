using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Duikboot.Data.Live;
using Duikboot.Data.Live.Models;
using Duikboot.Registration.Web.Models;
using Mollie.Api.Client;
using Mollie.Api.Client.Abstract;
using Mollie.Api.Models.Payment;
using Mollie.Api.Models.Payment.Request;
using Mollie.Api.Models.Payment.Response;


namespace Duikboot.Registration.Web.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IPaymentClient paymentClient;
        private MeerijderRepository meerijderRepository;

        public RegistrationController()
        {
            this.paymentClient = new PaymentClient(ConfigurationManager.AppSettings["MollieLiveKey"]);
            this.meerijderRepository = new MeerijderRepository();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult GetAvailability()
        {
            return Json(meerijderRepository.GetAvailableDates(),JsonRequestBehavior.AllowGet); 
        }

        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Register(Meerijder meerijder)
        {

            meerijder = Data.Live.ExtensionMethods.Extension.NullToBool(meerijder);

            PaymentRequest paymentRequest = new PaymentRequest();
            paymentRequest.Amount = (decimal)meerijder.Amount;
            paymentRequest.Description = $"Betaling carnaval 2018 met CV D'n Duikboot - {meerijder.Firstname} {meerijder.Surname}";
            var test = this.Url.Action("Complete", "Registration", Request.Url.Scheme);
            paymentRequest.RedirectUrl = HttpContext.Request.Url.Scheme + "://" + HttpContext.Request.Url.Authority + Url.Action("Complete", "Registration", null);
            ;
            PaymentResponse paymentResponseOne = await this.paymentClient.CreatePaymentAsync(paymentRequest);
            PaymentResponse paymentResponse = await this.paymentClient.GetPaymentAsync(paymentResponseOne.Id);
            Session["PaymentRequest"] = paymentResponseOne.Id;
            Session["Meerijder"] = meerijder;
            return this.Redirect(paymentResponse.Links.PaymentUrl);
        }


        [HttpGet]
        public async Task<ActionResult> Complete()
        {
            string paymentRequest = Session["PaymentRequest"].ToString();
            PaymentResponse paymentResponse = await this.paymentClient.GetPaymentAsync(paymentRequest);
            switch (paymentResponse.Status)
            {
                case (PaymentStatus.Paid):
                    Meerijder meerijder = Session["Meerijder"] as Meerijder;
                    meerijderRepository.Add(meerijder);
                    return View("Complete");
                default:
                    return View("Failed");
            }
        }
    }
}