using Fit_5032_NewCar.Models;
using Fit_5032_NewCar.E_mail_Sending_Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fit_5032_NewCar.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Send_Email()
        {
            return View(new Vmodel());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Send_Email(Vmodel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;
                    String fp = model.FP;

                    EmailSender es = new EmailSender();
                    es.Send(toEmail, subject, contents,fp);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new Vmodel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

    }
}