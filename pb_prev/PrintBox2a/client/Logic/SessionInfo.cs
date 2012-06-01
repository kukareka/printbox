using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;
using PrintBox.Logic.Wrappers;

namespace PrintBox.Logic
{
    public class SessionInfo
    {
        public string userPhone = null;
        public string passwordMD5;
        public float userMoney;
        public int moneyInSession = 0;
        public int banknotesInSession = 0;
        public IDocumentWrapper documentWrapper = null;
        public Microsoft.Office.Interop.Word.Document wordDoc;
        public int pagesInDoc;
        public string longDocPath;
        public string shortDocPath;
        public string docName;
        private int currentPage = 1;
        public int CurrentPage
        {
            get { return currentPage; }
            set
            {
                if ((value > 0) && (value <= pagesInDoc))
                {
                    currentPage = value;
                    documentWrapper.GoToPage(currentPage);
                }
            }
        }
    }
}
