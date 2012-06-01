using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrintBox.Logic.Wrappers;

namespace PrintBox.Logic
{
    public class FormatManager
    {
        public int GetIconIndex(string ext)
        {
            if ((ext == ".doc") || (ext == ".docx") || (ext == ".rtf")) return 1;
            else if (ext == ".pdf") return 2;
            else return 0;
        }

        public IDocumentWrapper LoadDocument()
        {
            PrintBoxApp.instance.wordWrapper.CloseDocument();
            PrintBoxApp.instance.pdfWrapper.CloseDocument();

            IDocumentWrapper wr;
            string docPath = PrintBoxApp.instance.sessionInfo.shortDocPath.ToLower();
            if (docPath.EndsWith(".doc") || docPath.EndsWith(".docx") || docPath.EndsWith(".rtf")) wr = PrintBoxApp.instance.wordWrapper;
            else if (docPath.EndsWith(".pdf")) wr = PrintBoxApp.instance.pdfWrapper;
            else return null;

            wr.LoadDocument();
            return wr;            
        }
    }
}
