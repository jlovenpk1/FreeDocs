using FreeDocs.Models.EFConfigs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeDocs.Controllers._RegLogic
{
    interface IReg
    {
        string LoginCheck(string name);
        string MailCheck(string mail);

    }
}
