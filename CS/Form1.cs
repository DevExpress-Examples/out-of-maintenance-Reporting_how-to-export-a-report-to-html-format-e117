using System;
using System.Windows.Forms;

using System.Drawing;
using System.Diagnostics;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
// ...


namespace ExportToHtmlCS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // A path to export a report.
            string reportPath = "c:\\Test.html";

            // Create a report instance.
            XtraReport1 report = new XtraReport1();

            // Get its HTML export options.
            HtmlExportOptions htmlOptions = report.ExportOptions.Html;

            // Set HTML-specific export options.
            htmlOptions.CharacterSet = "UTF-8";
            htmlOptions.RemoveSecondarySymbols = false;
            htmlOptions.Title = "Test Title";

            // Set the pages to be exported, and page-by-page options.
            htmlOptions.ExportMode = HtmlExportMode.SingleFilePageByPage;
            htmlOptions.PageRange = "1, 3-5";
            htmlOptions.PageBorderColor = Color.Blue;
            htmlOptions.PageBorderWidth = 3;

            // Export the report to HTML.
            report.ExportToHtml(reportPath);

            // Show the result.
            StartProcess(reportPath);
        }

        // Use this method if you want to automaically open
        // the created HTML file in the default program.
        public void StartProcess(string path)
        {
            Process process = new Process();
            try
            {
                process.StartInfo.FileName = path;
                process.Start();
                process.WaitForInputIdle();
            }
            catch { }
        }
    }
}