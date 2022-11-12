using calendar.GenerationStrategy.DoubleSided.Models;
using calendar.PDF;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calendar.GenerationStrategy.DoubleSided {
    public class DoubleSidedGenerationStrategy : IGenerationStrategy {
        private List<DoubleSidedPage> _pages;
        private string _template;

        public DoubleSidedGenerationStrategy(int year)
        {
            _pages = new List<DoubleSidedPage>();
            _template = File.ReadAllText("Templates/TemplateDoubleSided.html");

            InitializePages(year);
        }

        private void InitializePages(int year)
        {
            DateTime startDate = CalendarHelper.FirstDateOfWeek(year, 1);

            while ((ISOWeek.GetWeekOfYear(startDate) == 1 && startDate.Year == year + 1) || (startDate.Year  == year && ISOWeek.GetWeekOfYear(startDate) <= 52))
            {
                var frontLeft = new List<DateTime>();
                var frontRight = new List<DateTime>();
                var backLeft = new List<DateTime>();
                var backRight = new List<DateTime>();

                for (int i = -3; i <= 10; i++)
                {
                    var nextDate = startDate.AddDays(i);

                    if (i >= -3 && i <= -1)
                        backRight.Add(nextDate);

                    if (i >= 0 && i <= 3)
                        frontLeft.Add(nextDate);

                    if (i >= 4 && i <= 6)
                        frontRight.Add(nextDate);

                    if (i >= 7 && i <= 10)
                        backLeft.Add(nextDate);
                }

                var front = new SplittedPage(new Subpage(frontLeft), new Subpage(frontRight));
                var back = new SplittedPage(new Subpage(backLeft), new Subpage(backRight));

                _pages.Add(new DoubleSidedPage(front, back));

                startDate = startDate.AddDays(14);
            }
        }

        private string GenerateTemplate(SplittedPage page)
        {
            string frontTemplate = _template;

            // Left
            frontTemplate = frontTemplate.Replace("{{MONTH_LEFT}}", $"{page.Left.GetMonth()} {page.Left.GetYear()}");
            frontTemplate = frontTemplate.Replace("{{KALENDERWOCHE_LEFT}}", $"{page.Left.GetWeekOfYear()}");
            frontTemplate = frontTemplate.Replace("{{FROM_DATE_LEFT}}", $"{page.Left.GetFirstDay()}");
            frontTemplate = frontTemplate.Replace("{{TO_DATE_LEFT}}", $"{page.Left.GetLastDay()}");

            for (int i = 0; i < 4; i++)
            {
                frontTemplate = frontTemplate.Replace($"{{{{DATE_{i + 1}_LEFT}}}}", $"{page.Left.GetDayOfMonth(i)}");
                frontTemplate = frontTemplate.Replace($"{{{{DATE_{i + 1}_WEEKDAY_LEFT}}}}", $"{page.Left.GetWeekDay(i)}");
            }

            // Right
            frontTemplate = frontTemplate.Replace("{{MONTH_RIGHT}}", $"{page.Right.GetMonth()} {page.Right.GetYear()}");
            frontTemplate = frontTemplate.Replace("{{KALENDERWOCHE_RIGHT}}", $"{page.Right.GetWeekOfYear()}");
            frontTemplate = frontTemplate.Replace("{{FROM_DATE_RIGHT}}", $"{page.Right.GetFirstDay()}");
            frontTemplate = frontTemplate.Replace("{{TO_DATE_RIGHT}}", $"{page.Right.GetLastDay()}");

            for (int i = 0; i < 3; i++)
            {
                frontTemplate = frontTemplate.Replace($"{{{{DATE_{i + 1}_RIGHT}}}}", $"{page.Right.GetDayOfMonth(i)}");
                frontTemplate = frontTemplate.Replace($"{{{{DATE_{i + 1}_WEEKDAY_RIGHT}}}}", $"{page.Right.GetWeekDay(i)}");
            }

            return frontTemplate;
        }

        private PdfDocument GeneratePdf(string template)
        {
            File.WriteAllText($"tmp.html", template);

            PDFUtils.InvokeWkHtmlToPdf($"-T 5 -B 5 -L 8 -R 8 -O Landscape tmp.html tmp.pdf");
            var generatedPdf = PdfReader.Open($"tmp.pdf", PdfDocumentOpenMode.ReadOnly);

            File.Delete($"tmp.html");
            File.Delete($"tmp.pdf");

            return generatedPdf;
        }

        private PdfDocument GenerateSingle(DoubleSidedPage page)
        {
            string frontTemplate = GenerateTemplate(page.Front);
            string backTemplate = GenerateTemplate(page.Back);

            var front = GeneratePdf(frontTemplate);
            var back = GeneratePdf(backTemplate);

            var merged = PDFUtils.MergePdfs(front, back);

            front.Close();
            back.Close();

            return merged;
        }

        public PdfDocument Generate(IProgress<Tuple<int, int>> progressCallback)
        {
            var result = new PdfDocument();

            int i = 0;
            foreach (var page in _pages)
            {
                var doc = GenerateSingle(page);
                PDFUtils.CopyPages(doc, result);
                doc.Close();

                i++;

                progressCallback.Report(Tuple.Create(i, _pages.Count));
            }

            return result;
        }
    }
}
