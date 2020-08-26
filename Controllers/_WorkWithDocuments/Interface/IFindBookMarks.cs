using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using FreeDocs.Models.Additional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeDocs.Controllers._WorkWithDocuments.Interface
{
    public interface IFindBookMarks
    {
        void Run(string type, string name);
        void FindMarks(Body document);
        void ReplaceMarks(Text text);
        void WorkWithText(Body document);
    }
}