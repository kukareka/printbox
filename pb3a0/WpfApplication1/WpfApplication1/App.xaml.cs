using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Xps.Packaging;
using Microsoft.Win32;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Diagnostics;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string XPS_PRINTER_NAME = "Microsoft XPS Document Writer";
        public DocumentInfo documentInfo = new DocumentInfo();
        public XpsDocument xpsDocument = null;
        object missing = Type.Missing;

        string[] supportedExtensions = new string[] { ".doc", ".docx", ".rtf" };

        public bool IsSupportedExtension(string ext)
        {
            return Array.IndexOf(supportedExtensions, ext) != -1;
        }

        public bool ConvertToXPS(string srcDocPath, string dstDocPath)
        {
            bool result = false;

            if (IsSupportedExtension(Path.GetExtension(srcDocPath)))
            {
                try
                {
                    Word.Application wordApp = new Word.Application();

                    try
                    {
                        wordApp.Visible = false;

                        object docPath = srcDocPath, confirmConversions = false, readOnly = true,
                            addToRecent = false, passwordDocument = missing, passwordTemplate = missing, revert = true,
                            writePasswordDocument = missing, writePasswordTemplate = missing, format = Word.WdOpenFormat.wdOpenFormatAuto,
                            encoding = missing, visible = true, openAndRepair = false, documentDirection = missing, noEncodingDialog = true,
                            xmlTransform = missing;
                        Word.Document wordDoc = wordApp.Documents.OpenNoRepairDialog(ref docPath, ref confirmConversions, ref readOnly, ref addToRecent,
                            ref passwordDocument, ref passwordTemplate, ref revert, ref writePasswordDocument, ref writePasswordTemplate, ref format, ref encoding,
                            ref visible, ref openAndRepair, ref documentDirection, ref noEncodingDialog, ref xmlTransform);

                        try
                        {
                            this.documentInfo.PageCount = wordDoc.ComputeStatistics(Word.WdStatistic.wdStatisticPages);
                            object background = false, range = Word.WdPrintOutRange.wdPrintAllDocument, outputFileName = dstDocPath,
                                copies = 1, pageType = Word.WdPrintOutPages.wdPrintAllPages, printToFile = true, collate = false,
                                manualDuplexPrint = false, printZoomColumn = 1, printZoomRow = 1;
                            wordApp.ActivePrinter = XPS_PRINTER_NAME;
                            wordDoc.PrintOut(ref background, ref missing, ref range, ref outputFileName,
                                ref missing, ref missing, ref missing, ref copies,
                                ref missing, ref pageType, ref printToFile, ref collate,
                                ref missing, ref manualDuplexPrint, ref printZoomColumn,
                                ref printZoomRow, ref missing, ref missing);

                            result = true;
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.StackTrace);
                        }

                        {
                            object saveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
                            wordDoc.Close(ref saveChanges);
                        }
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.StackTrace);
                    }

                    {
                        object saveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
                        wordApp.Quit(ref saveChanges, ref missing, ref missing);
                    }

                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.StackTrace);
                }
            }

            return result;
        }



        public bool LoadDocument(string documentPath)
        {
            documentInfo.documentPath = documentPath;

            if (xpsDocument != null)
            {
                xpsDocument.Close();
            }

            documentInfo.xpsDocumentPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToBinary().ToString("x") + ".xps");

            if (ConvertToXPS(this.documentInfo.documentPath, this.documentInfo.xpsDocumentPath))
            {
                xpsDocument = new XpsDocument(this.documentInfo.xpsDocumentPath, System.IO.FileAccess.Read);
                documentInfo.CurrentPage = 0;
                (MainWindow as MainWindow).LoadDocument();
                return true;
            }
            else return false;
        }
    }
}
