using System.Net.Mail;

namespace heilbrigt_workplace_backend_v01.Services
{
    public class SendMail
    {

        public string Subject { get; set; } = string.Empty;

        public string Recipient {  get; set; } = string.Empty;

        public string Sender { get; set; } = string.Empty;

        public string SenderName {  get; set; } = string.Empty; 

        public string ReplyToList { get; set; } = string.Empty;

        public string Body {  get; set; } = string.Empty;

        public void MailSending(SendMail MailData)
        {

            MailMessage mail = new MailMessage();
            mail.To.Add(MailData.Recipient);
            mail.From = new MailAddress(Sender, SenderName);
            mail.ReplyToList.Add(new MailAddress(ReplyToList));
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.BodyEncoding = System.Text.Encoding.UTF8;

            SmtpClient smtp = new SmtpClient();
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.strato.de";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("website@warelabs.de", "!Iliotec230.9rH7"); //Ändern!!! Nur für Testzwecke
            smtp.Send(mail);
        }
    }
}
