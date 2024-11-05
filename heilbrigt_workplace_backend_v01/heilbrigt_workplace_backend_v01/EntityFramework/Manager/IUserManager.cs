using heilbrigt_workplace_backend_v01.Dtos.UserSystem;
using heilbrigt_workplace_backend_v01.EntityFramework.Context;
using heilbrigt_workplace_backend_v01.Services;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace heilbrigt_workplace_backend_v01.EntityFramework.Manager
{
    public interface IUserManager
    {
        public RequestResponse AddNewUser(UserFullDto user);
    }

    public class UserManager : IUserManager
    {
        HeilbrigtContext context = new HeilbrigtContext();

        public RequestResponse AddNewUser(UserFullDto user)
        {
            //AddUser to Database
            var adduser = context.User.FirstOrDefault(editor => editor.userMail == user.email);
            if (adduser != default)
                throw new KeyNotFoundException($"Die Email Adresse '{user.email}' ist bereits vorhanden!");

            // If needed: Create new model
            if (adduser == default)
                adduser = new();

            //Generate SessionId
            var s = RandomKey.RandomStringGen(5);
            string sI = GenerateHash.ComputeSha512Hash(s.RandomString);

            //Generate Password
            var initialPassword = RandomKey.RandomStringGen(8);

            //Set SQL DATA
            adduser.userMail = user.email;
            adduser.userLastName = user.lastname;
            adduser.userFirstName = user.firstname;
            adduser.userInternalId = user.userid;
            adduser.userIsActiveated = false;
            adduser.userAddDate = DateTime.Now;
            adduser.userSessionId = sI;
            adduser.userPasswordHash = BCrypt.Net.BCrypt.HashPassword(initialPassword.RandomString);

            //Mail senden einfügen!
            SendMail MailData = new SendMail
            {
                Recipient = user.email,
                Subject = "Ihr Zugang bei EG",
                Sender = "website@warelabs.de",
                SenderName = "WareLabs",
                ReplyToList = "kontakt@warelabs.de1",
                Body = $@"
                        <style>

body {{backgroundcolor: grey; margin: 4%;}}
</style>
<html>
<body>
Guten Tag {user.firstname}, <br><br>
für deine erste Anmeldung verwende bitte folgende Daten: <br><br>
Anemledename: {user.lastname}<br>
Initialpassword: {initialPassword.RandomString}<br><br>
Diese Email dürfen Sie nicht weiterleiten, sowie die Daten nicht an Dritte weitergeben!
<br>
<br>
<a href='localhost:4200/usersystem/firstlogin?sId={sI}&name={user.lastname}'>Direkter Lnk</a>
<br>
</body>
</html>
                        "//Body

            };

            //MailData.MailSending(MailData);

            context.Add(adduser);
            context.SaveChanges();

            return new RequestResponse
            {
                ResponseCode = 1,
                ResponseText = "Erfolgreich gespeichert!"
            };

        }

    }

    public class RequestResponse
    {
        public string ResponseText { get; set; } = string.Empty;

        public int ResponseCode { get; set; } = 0;

    }
}
