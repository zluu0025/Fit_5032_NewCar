using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Fit_5032_NewCar.E_mail_Sending_Function
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "SG.GjrtkbD5RM2f8hHO8SG0kg.cbRM3meRyYlnoWuxG5ZiiDo - SQn1AvBs3fG3R2zqFsw";

        public void Send(String toEmail, String subject, String contents, String FP)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("noreply@localhost.com", "FIT5032 Example Email User");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            if (FP != null)
            {
                string fullPath = Path.Combine("/Users/PX Hao/source/repos/Fit_5032_NewCar/Fit_5032_NewCar/File Saved", FP);
                string fileName = Path.GetFileName(fullPath);
                string type = Path.GetExtension(fullPath);
                var bytes = File.ReadAllBytes(fullPath);
                var file02 = Convert.ToBase64String(bytes);
                msg.AddAttachment(fileName, file02, type);
            }
            var response = client.SendEmailAsync(msg);

        }

    }
}