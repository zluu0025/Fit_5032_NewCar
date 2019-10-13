using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Fit_5032_NewCar.Controllers;
using Fit_5032_NewCar.Models;


namespace Fit_5032_NewCar.Controllers
{
    public class UploadFileController : Controller
    {
        // GET: UploadFile
        public ActionResult FileS()
        {
            return View();
        }

        public ActionResult FileS(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {

                    string filename = Path.GetFileName(file.FileName);
                    string filepath = Path.Combine(Server.MapPath("~/File Saved"), filename);
                    file.SaveAs(filepath);


                }
                ViewBag.Message = "Upload file Saved Successfully in the folder";
                return View();
            }
            catch
            {

                ViewBag.Message = "Upload file Saved Successfully in the folder";
                return View();
            }

        }

    }
}