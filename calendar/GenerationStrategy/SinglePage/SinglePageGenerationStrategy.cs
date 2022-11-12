using calendar.GenerationStrategy.SinglePage.Models;
using calendar.PDF;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar.GenerationStrategy.SinglePage {

    internal class SinglePageGenerationStrategy : IGenerationStrategy {
        private List<Page> _pages;
        private string _template;

        public SinglePageGenerationStrategy(int year)
        {
            _pages = new List<Page>();
            _template = File.ReadAllText("Templates/TemplateSequential.html");

            InitializePages(year);
        }

        private void InitializePages(int year)
        {
            // Partition into 1-week per page
            DateTime startDate = CalendarHelper.FirstDateOfWeek(year, 1);
            int numKWs = ISOWeek.GetWeeksInYear(year);

            for (int i = 0; i < numKWs; i++)
            {
                var dates = new List<DateTime>();

                for (int j = 0; j < 7; j++)
                    dates.Add(startDate.AddDays(j));

                startDate = startDate.AddDays(7);

                _pages.Add(new Page(dates, i + 1));
            }
        }

        public PdfDocument Generate(IProgress<Tuple<int, int>> progressCallback)
        {
            PdfDocument result = new PdfDocument();

            int i = 0;
            foreach (var page in _pages)
            {
                var generated = GeneratePdf(page);
                PDFUtils.CopyPages(generated, result);
                generated.Close();

                progressCallback.Report(Tuple.Create(++i, _pages.Count));
            }

            return result;
        }

        private PdfDocument GeneratePdf(Page page)
        {
            string template = _template;
            PdfDocument? result = null;

            template = template.Replace("{{KALENDERWOCHE}}", page.WeekOfYear().ToString());
            template = template.Replace("{{JAHR}}", page.GetYear().ToString());

            for (int i = 0; i < 7; i++)
            {
                template = template.Replace($"{{{{WEEK_DAY_{i + 1}}}}}", page.GetWeekDay(i));
                template = template.Replace($"{{{{DATE_{i + 1}}}}}", page.GetDate(i));
                
            }

            File.WriteAllText("tmp.html", template);
            PDFUtils.InvokeWkHtmlToPdf($"tmp.html tmp.pdf");
            File.Delete("tmp.html");
            result = PdfReader.Open("tmp.pdf", PdfDocumentOpenMode.ReadOnly);
            File.Delete("tmp.pdf");

            return result;
        }
    }
}
