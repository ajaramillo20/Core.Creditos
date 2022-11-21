using Org.BouncyCastle.Asn1.IsisMtt.X509;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Creditos.Adapters.wkhtmlpdf
{
    public static class WKHtmlADP
    {
        public static void HtmlToPdf(string htmlSource)
        {
            var x  = AppDomain.CurrentDomain.BaseDirectory;

            var ruta = $"{AppDomain.CurrentDomain.BaseDirectory}wkhtmlpdf\\wkhtmltopdf.exe";

            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.UseShellExecute = false;
            processStartInfo.FileName = x;
        }
    }
}
