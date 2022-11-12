using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar.PDF {
    public class PDFUtils {
        public static void CopyPages(PdfDocument from, PdfDocument to)
        {
            /* 
             * Since PdfSharp can only copy pages from imported documents,
             * we need to store the document into a temporary stream.
            */
            using (var stream = new MemoryStream())
            {
                int pages = from.PageCount;
                from.Save(stream);
                var imported = PdfReader.Open(stream, PdfDocumentOpenMode.Import);

                for (int i = 0; i < imported.PageCount; i++)
                    to.AddPage(imported.Pages[i]);
            }
        }

        public static PdfDocument MergePdfs(params PdfDocument[] documents)
        {
            var result = new PdfDocument();

            foreach (var document in documents)
                CopyPages(document, result);

            return result;
        }

        public static void InvokeWkHtmlToPdf(string args)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "wkhtmltopdf.exe";
            startInfo.Arguments = args;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.UseShellExecute = false;
            startInfo.CreateNoWindow = true;

            Process processTemp = new Process();
            processTemp.StartInfo = startInfo;
            processTemp.EnableRaisingEvents = true;

            try
            {
                processTemp.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to generate one or more PDFs", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            processTemp.WaitForExit();
        }
    }
}
