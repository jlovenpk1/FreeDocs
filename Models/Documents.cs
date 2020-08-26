using FreeDocs.Models.Additional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreeDocs.Models
{
    public class Documents
    {
        /// <summary>
        /// ID - уникальный порядковый номер
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Имя документа для сайта
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Название документа
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Путь к документу
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Тип документа
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Дата загрузки
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Описание документа
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Путь до изображения
        /// </summary>
        public string ImgURL { get; set; }
    }
}