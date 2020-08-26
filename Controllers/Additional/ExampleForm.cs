using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeDocs.Controllers.HomeController
{
    public  class ExampleForm
    {
        public string NameCompany { get; set; }
        public string FIO { get; set; }
        public string FIOClient { get; set; }
        public DateTime date { get;set; }
        public DateTime date_end { get; set; }
        public DateTime date_vac { get; set; }
        public DateTime date_today { get; set; }
    }
}