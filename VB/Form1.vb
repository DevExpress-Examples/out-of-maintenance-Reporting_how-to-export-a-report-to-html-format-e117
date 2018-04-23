Imports System.Drawing
Imports System.Diagnostics
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
' ...


Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' A path to export a report.
        Dim reportPath As String = "c:\\Test.html"

        ' Create a report instance.
        Dim report As New XtraReport1()

        ' Get its HTML export options.
        Dim htmlOptions As HtmlExportOptions = report.ExportOptions.Html

        ' Set HTML-specific export options.
        htmlOptions.CharacterSet = "UTF-8"
        htmlOptions.RemoveSecondarySymbols = False
        htmlOptions.Title = "Test Title"

        ' Set the pages to be exported, and page-by-page options.
        htmlOptions.ExportMode = HtmlExportMode.SingleFilePageByPage
        htmlOptions.PageRange = "1, 3-5"
        htmlOptions.PageBorderColor = Color.Blue
        htmlOptions.PageBorderWidth = 3

        ' Export the report to HTML.
        report.ExportToHtml(reportPath)

        ' Show the result.
        StartProcess(reportPath)
    End Sub

    ' Use this method if you want to automaically open
    ' the created HTML file in the default program.
    Public Sub StartProcess(ByVal path As String)
        Dim process As New Process()
        Try
            process.StartInfo.FileName = path
            process.Start()
            process.WaitForInputIdle()
        Catch
        End Try
    End Sub
End Class
