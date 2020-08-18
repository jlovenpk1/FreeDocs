using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeDocs.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DateReg { get; set; }
        public string Mail { get; set; }
        public int aAccount { get; set; }

    }
}