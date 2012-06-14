﻿using System;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Diagnostics;

namespace WpfApplication1
{
    public class XpsWrapper
    {
        private static string XPS_PRINTER_NAME = "Microsoft XPS Document Writer";

        string[] supportedExtensions = new string[] { ".doc", ".docx", ".rtf" };

        public XpsWrapper()
        {
            foreach (string f in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "doc_*.xps"))
                try { File.Delete(f); }
                catch (Exception) { }
        }

        public bool IsSupportedExtension(string ext)
        {
            return Array.IndexOf(supportedExtensions, ext) != -1;
        }

        public bool ConvertToXPS(string srcDocPath)
        {
            string dstDocPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, String.Format("doc_{0}.xps", DateTime.Now.ToBinary().ToString("x")));
            (App.Current as App).sessionInfo.documentInfo.xpsDocumentPath = dstDocPath;

            bool result = false;

            if (IsSupportedExtension(Path.GetExtension(srcDocPath)))
            {
                try
                {
                    object missing = Type.Missing;
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
                            (App.Current as App).sessionInfo.documentInfo.PageCount = wordDoc.ComputeStatistics(Word.WdStatistic.wdStatisticPages);
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
    }
}
