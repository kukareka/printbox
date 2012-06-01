using PrintBox.GUI.Forms;
using AxAcroPDFLib;
using PrintBoxMain.UserControls;

namespace PrintBox.Logic.Wrappers
{
    public class PdfWrapper : IDocumentWrapper
    {
        AxAcroPDF pdfReader = null;

        public bool PrintZoomEnabled()
        {
            return false;
        }

        public void SetReader(AxAcroPDF pdfReader)
        {
            this.pdfReader = pdfReader;
        }

        public void Show()
        {
            pdfReader.Visible = true;
        }

        public void SetPos(DocView docView)
        {
            pdfReader.Left = PrintBoxApp.instance.config.PdfLeft;
            pdfReader.Top = PrintBoxApp.instance.config.PdfTop;
            pdfReader.Width = docView.pnlWord.Width -
                PrintBoxApp.instance.config.PdfLeft + PrintBoxApp.instance.config.PdfRight;
            pdfReader.Height = docView.pnlWord.Height -
                PrintBoxApp.instance.config.PdfTop + PrintBoxApp.instance.config.PdfBottom;
        }

        public void LoadDocument()
        {
            pdfReader.LoadFile(PrintBoxApp.instance.sessionInfo.shortDocPath);
            pdfReader.setShowToolbar(false);
            pdfReader.setShowScrollbars(false);
            pdfReader.setLayoutMode("SinglePage");
            pdfReader.setPageMode("none");
            GoToPage(1);

            iTextSharp.text.pdf.PdfReader rd = new iTextSharp.text.pdf.PdfReader(PrintBoxApp.instance.sessionInfo.shortDocPath);
            PrintBoxApp.instance.sessionInfo.pagesInDoc = rd.NumberOfPages;
        }

        public void GoToPage(int page)
        {
            pdfReader.setCurrentPage(page);
        }

        public void PrintDocument()
        {
            if ((PrintBoxApp.instance.printOptions.from == 1) &&
                (PrintBoxApp.instance.printOptions.to == PrintBoxApp.instance.sessionInfo.pagesInDoc))
            {
                for (int copy = 0; copy < PrintBoxApp.instance.printOptions.copies; ++copy)
                {
                    pdfReader.printAll();
                }
            }
            else
            {
                for (int copy = 0; copy < PrintBoxApp.instance.printOptions.copies; ++copy)
                {
                    pdfReader.printPages(PrintBoxApp.instance.printOptions.from, PrintBoxApp.instance.printOptions.to);
                }                 
            }
        }

        public void CloseDocument()
        {
            pdfReader.Visible = false;
        }
    }
}
