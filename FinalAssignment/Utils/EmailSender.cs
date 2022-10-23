using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EmailSending.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents, HttpPostedFileBase postedFile)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("demo512022s2@outlook.com", "FIT5032 Example Email User");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            using (var memoryStream = new MemoryStream())
            {
                // 1. convert attach file to inputStream
                postedFile.InputStream.CopyTo(memoryStream);
                // 2. convert inputstream to byte array
                byte[] bytes = memoryStream.ToArray();
                Attachment attachment = new Attachment();
                // 3. convert to base64 type(String)
                attachment.Content = Convert.ToBase64String(bytes);
                attachment.Filename = postedFile.FileName;
                // 4. add this attachment to email message
                msg.AddAttachment(attachment.Filename, attachment.Content);
            }

            var response = client.SendEmailAsync(msg);
        }

    }
}