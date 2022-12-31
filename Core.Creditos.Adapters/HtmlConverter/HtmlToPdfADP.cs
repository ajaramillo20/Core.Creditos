using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelectPdf;

namespace Core.Creditos.Adapters.HtmlConverter
{
    public static class HtmlToPdfADP
    {
        /// <summary>
        /// IMPORTANTE: Esta versión solo permite covnertir un máximo de 5 páginas
        /// </summary>
        /// <param name="source"></param>
        /// <param name="fileNme"></param>
        public static void ConvertHtmlStringToPdf(string source, string fileNme)
        {
            HtmlToPdf converter = new HtmlToPdf();
            // convert the url to pdf
            PdfDocument doc = converter.ConvertHtmlString(source);
            // save pdf document
            doc.Save(fileNme);
            // close pdf document
            doc.Close();
        }
    }
}
