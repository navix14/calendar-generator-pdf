using calendar.GenerationStrategy;
using calendar.GenerationStrategy.DoubleSided;
using calendar.GenerationStrategy.SinglePage;
using System.Text;

namespace calendar {
    public partial class frmCalendarTool : Form {
        public frmCalendarTool()
        {
            InitializeComponent();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        private void ReportProgess(Tuple<int, int> info)
        {
            double current = info.Item1;
            double total = info.Item2;

            progressGenerate.Value = (int)(current / total * 100);
            lblStatus.Text = $"{current} / {total}";
        }

        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtYear.Text, out int year))
            {
                MessageBox.Show($"'{txtYear.Text}' is not a valid year");
                return;
            }

            IGenerationStrategy strategy;

            if (radioSinglePage.Checked)
                strategy = new SinglePageGenerationStrategy(year);
            else
                strategy = new DoubleSidedGenerationStrategy(year);

            var progress = new Progress<Tuple<int, int>>(ReportProgess);

            await Task.Factory.StartNew(() =>
            {
                var result = strategy.Generate(progress);
                result.Save("result.pdf");
            }, creationOptions: TaskCreationOptions.LongRunning);

            lblStatus.Text = "Idle";
        }
    }
}