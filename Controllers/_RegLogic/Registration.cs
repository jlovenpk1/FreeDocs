using FreeDocs.Models.EFConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace FreeDocs.Controllers._RegLogic
{
    public class Registration : IReg
    {
        public ApplicationContext db;
        struct Status
        {
            public const string WrongLogin = "Данный логин уже существует!";
            public const string GoodLogin = "Логин не занят!";
            public const string WrongMail = "Почта уже используется";
            public const string GoodMail = "Почта свободна";
        }

        public string LoginCheck(string name)
        {
            db = new ApplicationContext();
            var result = db.Users.Where(x => x.Login == name);
            if (result.Count() == 0) { return Status.GoodLogin; }
            else
            { return Status.WrongLogin; }
        }

        public string MailCheck(string mail)
        {
            db = new ApplicationContext();
            var result = db.Users.Where(x => x.Mail == mail);
            if (result.Count() == 0) { return Status.GoodMail; }
            else
            { return Status.WrongMail; }
        }
    }
}