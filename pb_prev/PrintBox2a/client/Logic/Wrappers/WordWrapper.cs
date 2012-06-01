using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Diagnostics;
using Microsoft.Win32;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;
using System.Threading;
using PrintBox.GUI.Forms;
using PrintBoxMain.UserControls;

namespace PrintBox.Logic.Wrappers
{
    public class WordWrapper : IDocumentWrapper
    {
        ILog log = LogManager.GetLogger(typeof(WordWrapper));

        public Microsoft.Office.Interop.Word.Application wordApp;

        public WordWrapper()
        {
            try
            {
                TerminateWord();
                wordApp = new Microsoft.Office.Interop.Word.Application();
            }
            catch (Exception e)
            {
                log.Error(e);
            }
        }

        public bool PrintZoomEnabled()
        {
            return true;
        }

        public void SetPos(DocView docView)
        {
            docView.pnlWordInner.Left = PrintBoxApp.instance.config.WordLeft;
            docView.pnlWordInner.Top = PrintBoxApp.instance.config.WordTop;
            docView.pnlWordInner.Width = docView.pnlWord.Width -
                PrintBoxApp.instance.config.WordLeft + PrintBoxApp.instance.config.WordRight;
            docView.pnlWordInner.Height = docView.pnlWord.Height -
                PrintBoxApp.instance.config.WordTop + PrintBoxApp.instance.config.WordBottom;
            wordApp.ActiveWindow.WindowState =
                Microsoft.Office.Interop.Word.WdWindowState.wdWindowStateMaximize;
        }

        public void Show()
        {
            wordApp.Visible = true;
        }

        public void LoadDocument()
        {
            log.Debug("opening doc");
            CloseDocument();
            Thread asyncWatcher = new Thread(LoadDocumentWatcher);
            try
            {
                asyncWatcher.Start(Thread.CurrentThread);
                LoadDocumentAsync();
                asyncWatcher.Interrupt();
            }
            catch (ThreadAbortException e)
            {
                log.Error(e);
                Thread.ResetAbort();
                throw new Exception("Word timeout", e);
            }
            catch (Exception e)
            {
                log.Error(e);
                throw new Exception("Failed to load Word", e);
            }

            object missing = System.Reflection.Missing.Value;
            PrintBoxApp.instance.sessionInfo.pagesInDoc = PrintBoxApp.instance.sessionInfo.wordDoc.ComputeStatistics(Microsoft.Office.Interop.Word.WdStatistic.wdStatisticPages, ref missing);
            log.DebugFormat("loaded {0} pages", PrintBoxApp.instance.sessionInfo.pagesInDoc);
            wordApp.DisplayStatusBar = false;

            wordApp.ActiveWindow.ActivePane.View.Type = WdViewType.wdPrintPreview;
            wordApp.ActiveWindow.ActivePane.View.Zoom.PageFit = WdPageFit.wdPageFitFullPage;
        }

        public static void LoadDocumentWatcher(object ownerThread)
        {
            try
            {
                TimeSpan timeToWait = new TimeSpan(0, 0, PrintBoxApp.instance.config.WordTimeout);
                Thread.Sleep(timeToWait);
                ((Thread)ownerThread).Abort();

            }
            catch (ThreadInterruptedException) {}            
        }

        private void LoadDocumentAsync()
        {
            log.Debug("load doc async");                

            object dontsaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
            object missing = System.Reflection.Missing.Value;

            log.Debug("Close word docs");
            try
            {
                if (wordApp.Documents.Count > 0)
                {
                    wordApp.ActiveWindow.ActivePane.View.Type = WdViewType.wdNormalView;
                    wordApp.Documents.Close(ref dontsaveChanges, ref missing, ref missing);
                }
            }
            catch (Exception) { }
            log.Debug("Set parent");
            int wordWnd = WinApi.FindWindow("Opusapp", null);
            PrintBoxApp.instance.guiManager.EmbedWord(wordWnd);

            wordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            wordApp.Options.CheckGrammarAsYouType = wordApp.Options.CheckGrammarWithSpelling = wordApp.Options.CheckSpellingAsYouType =
                wordApp.DisplayScrollBars = wordApp.DisplayDocumentInformationPanel = false;
            foreach (CommandBar cb in wordApp.CommandBars)
            {
                try
                {
                    cb.Enabled = false;
                    cb.Visible = false;
                }
                catch { }
            }

            object fileName = PrintBoxApp.instance.sessionInfo.longDocPath;
            object newTemplate = false;
            //object docType = 0;
            object readOnly = true;
            object isVisible = true;
            object securelyStoredPassword = 0;
            object confirmConversions = false;
            //object format = WdOpenFormat.wdOpenFormatDocument;
            PrintBoxApp.instance.sessionInfo.wordDoc = wordApp.Documents.Open(ref fileName, ref confirmConversions, ref readOnly, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);
        }

        public void GoToPage(int page)
        {
            object missing = System.Reflection.Missing.Value;
            Range wholeRange = PrintBoxApp.instance.sessionInfo.wordDoc.Range(ref missing, ref missing);
            object what = WdGoToItem.wdGoToPage;
            object which = WdGoToDirection.wdGoToAbsolute;
            object count = page;
            Range range = wholeRange.GoTo(ref what, ref which, ref count, ref missing);
            range.Select();
        }

        public void PrintDocument()
        {
            object missing = System.Reflection.Missing.Value;
            object Background = false;
            object Range = Microsoft.Office.Interop.Word.WdPrintOutRange.wdPrintFromTo;
            object Copies = PrintBoxApp.instance.printOptions.copies.ToString();
            object Item = WdPrintOutItem.wdPrintDocumentContent;
            object PageType = WdPrintOutPages.wdPrintAllPages;
            object OutputFileName = missing;
            object PrintToFile = false;
            object Collate = false;
            object ActivePrinterMacGX = missing;
            object ManualDuplexPrint = false;
            object PrintZoomColumn = 1;
            object PrintZoomRow = 1;
            object what = WdGoToItem.wdGoToPage;
            object which = WdGoToDirection.wdGoToAbsolute;

            if (PrintBoxApp.instance.printOptions.pagesPerSheet == 2)
            {
                PrintZoomColumn = 2;
                PrintZoomRow = 1;
            }
            else if (PrintBoxApp.instance.printOptions.pagesPerSheet == 4)
            {
                PrintZoomColumn = 2;
                PrintZoomRow = 2;
            }

            if ((PrintBoxApp.instance.printOptions.from == 1) && 
                (PrintBoxApp.instance.printOptions.to == PrintBoxApp.instance.sessionInfo.pagesInDoc))
            {
                Range = Microsoft.Office.Interop.Word.WdPrintOutRange.wdPrintAllDocument;
                PrintBoxApp.instance.sessionInfo.wordDoc.PrintOut(ref Background, ref missing, ref Range, ref OutputFileName,
                    ref missing, ref missing, ref Item, ref Copies,
                    ref missing, ref PageType, ref PrintToFile, ref Collate,
                    ref missing, ref ManualDuplexPrint, ref PrintZoomColumn,
                    ref PrintZoomRow, ref missing, ref missing);
            }
            else
            {
                Range wholeRange = PrintBoxApp.instance.sessionInfo.wordDoc.Range(ref missing, ref missing);
                Copies = 1;
                for (int copy = 0; copy < PrintBoxApp.instance.printOptions.copies; ++copy)
                    for (int i = PrintBoxApp.instance.printOptions.from; i <= PrintBoxApp.instance.printOptions.to; i++)
                    {
                        object pageNumber = i;
                        Range rng = wholeRange.GoTo(ref what, ref which, ref pageNumber, ref missing);
                        rng.Select();
                        Range = Microsoft.Office.Interop.Word.WdPrintOutRange.wdPrintCurrentPage;
                        PrintBoxApp.instance.sessionInfo.wordDoc.PrintOut(ref Background, ref missing, ref Range, ref OutputFileName,
                            ref missing, ref missing, ref Item, ref Copies,
                            ref missing, ref PageType, ref PrintToFile, ref Collate,
                            ref missing, ref ManualDuplexPrint, ref PrintZoomColumn,
                            ref PrintZoomRow, ref missing, ref missing);
                    }
            }
        }

        public void CloseDocument()
        {
            log.Debug("Close document");
            try
            {
#pragma warning disable 0467                
                try
                {
                    object missing = System.Reflection.Missing.Value;
                    object dontsaveChanges = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
                    PrintBoxApp.instance.sessionInfo.wordDoc.Close(ref dontsaveChanges, ref missing, ref missing);
                }
                catch (Exception e) { log.Error(e); }

                PrintBoxApp.instance.sessionInfo.wordDoc = null;
#pragma warning restore 0467
            }
            catch (Exception e) { log.Error(e); }
        }

        
        public void TerminateWord()
        {
            log.Debug("Terminate word");
            foreach (Process proc in Process.GetProcessesByName("winword"))
            {
                proc.Kill();
                proc.WaitForExit(500);
            }

            try
            {
                Registry.CurrentUser.DeleteSubKeyTree(@"Software\Microsoft\Office\10.0\Word\Resiliency\DocumentRecovery");
            }
            catch { }
            try
            {
                Registry.CurrentUser.DeleteSubKeyTree(@"Software\Microsoft\Office\11.0\Word\Resiliency\DocumentRecovery");
            }
            catch { }
            try
            {
                Registry.CurrentUser.DeleteSubKeyTree(@"Software\Microsoft\Office\12.0\Word\Resiliency\DocumentRecovery");
            }
            catch { }
        }
        
    }
}
