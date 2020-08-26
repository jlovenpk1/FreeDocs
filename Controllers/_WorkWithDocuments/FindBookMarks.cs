using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using FreeDocs.Controllers._WorkWithDocuments.Interface;
using FreeDocs.Controllers.Additional;
using FreeDocs.Models.Additional;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FreeDocs.Controllers._WorkWithDocuments
{
    public sealed class FindBookMarks : IFindBookMarks
    {
        WordprocessingDocument _document; // Документ - шаблон с метками
        Body _body; // тело документа 
        List<string> _bookMarks; // найденные метки
        string pathFile = ""; // путь к файлу
        string pathFolder = ""; // путь к файлу

        /// <summary>
        /// Начать работу с документом шаблоном
        /// </summary>
        /// <param name="type">тип документа</param>
        /// <param name="name">имя документа</param>
        public void Run(string type, string name)
        {
            _bookMarks = new List<string>();
            switch (type)
            {
                case TypeDocs._act:
                    pathFile = AppDomain.CurrentDomain.BaseDirectory  + FolderName._document + "\\" + FolderName._act + "\\" + name;
                    pathFolder = AppDomain.CurrentDomain.BaseDirectory + FolderName._document + "\\" + FolderName._act + "\\" + DateTime.Now.ToString("dd-MM-yy-hh-mm-ss");
                    break;
                case TypeDocs._agreement:
                    pathFile = AppDomain.CurrentDomain.BaseDirectory + FolderName._document + "\\" + FolderName._agreement + "\\" + name;
                    pathFolder = AppDomain.CurrentDomain.BaseDirectory + FolderName._document + "\\" + FolderName._agreement + "\\" + DateTime.Now.ToString("dd-MM-yy-hh-mm-ss");
                    break;
                case TypeDocs._blank:
                    pathFile = AppDomain.CurrentDomain.BaseDirectory + FolderName._document + "\\" + FolderName._blank + "\\" + name;
                    pathFolder = AppDomain.CurrentDomain.BaseDirectory + FolderName._document + "\\" + FolderName._blank + "\\" + DateTime.Now.ToString("dd-MM-yy-hh-mm-ss");
                    break;
                case TypeDocs._reference:
                    pathFile = AppDomain.CurrentDomain.BaseDirectory + FolderName._document + "\\" + FolderName._reference + "\\" + name;
                    pathFolder = AppDomain.CurrentDomain.BaseDirectory + FolderName._document + "\\" + FolderName._reference + "\\" + DateTime.Now.ToString("dd-MM-yy-hh-mm-ss");
                    break;
            }
            Directory.CreateDirectory(pathFolder);
            File.Copy(pathFile, Path.Combine(pathFolder,name));
            pathFolder += "\\" + name;
            _document = WordprocessingDocument.Open(pathFolder, true);
            _body = _document.MainDocumentPart.Document.Body;
            FindMarks(_body);
            WorkWithText(_body);
            _document.Save();
            _document.Dispose();
        }

        /// <summary>
        /// Найти все метки Шаблон метки: [текст] или "[текст]"
        /// </summary>
        /// <param name="document"></param>
        public void FindMarks(Body document)
        {
            foreach (var text in document.Descendants<Text>())
            {
                var st = text.Text.Split(new char[] { ' ' });
                var mark = st.Where(x => (x.StartsWith("[")) || (x.StartsWith("«[") && x.EndsWith("]»")));
                if (mark.FirstOrDefault() != null) { _bookMarks.AddRange(mark); }
            }
        }

        /// <summary>
        /// Найти все марки и заменить их на текст
        /// </summary>
        /// <param name="text"></param>
        public void ReplaceMarks(Text text)
        {
            if (text.Text.Contains(_bookMarks.FirstOrDefault()))
            {
                text.Text = text.Text.Replace(_bookMarks.FirstOrDefault(), "Text");
                _bookMarks.Remove(_bookMarks.FirstOrDefault());
            }
            if (_bookMarks.Count != 0) { if (text.Text.Contains(_bookMarks.FirstOrDefault())) { ReplaceMarks(text); } }
            
        }

        /// <summary>
        /// Работа с текстом, в котором нужно поменять все метки
        /// </summary>
        /// <param name="document">Тело документа</param>
        public void WorkWithText(Body document)
        {
            foreach (var text in _body.Descendants<Text>())
            {
                if (_bookMarks.Count == 0) { break; }
                ReplaceMarks(text);
            }
        }
    }
}