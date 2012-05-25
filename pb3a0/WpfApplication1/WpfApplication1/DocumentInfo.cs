using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.IO;

namespace WpfApplication1
{
    public class DocumentInfo : DependencyObject
    {       
        public static DependencyProperty PageCountProperty =
            DependencyProperty.Register("PageCount", typeof(int), typeof(DocumentInfo),
            new PropertyMetadata(1, new PropertyChangedCallback(PageCountChanged) + new PropertyChangedCallback(PrintOptionsChanged)));
        
        public static DependencyProperty CurrentPageProperty =
            DependencyProperty.Register("CurrentPage", typeof(int), typeof(DocumentInfo));

        public static DependencyProperty CopiesProperty =
            DependencyProperty.Register("Copies", typeof(int), typeof(DocumentInfo),
            new PropertyMetadata(1, new PropertyChangedCallback(PrintOptionsChanged)));

        public static DependencyProperty PrintRangeFromProperty =
            DependencyProperty.Register("PrintRangeFrom", typeof(int), typeof(DocumentInfo),
            new PropertyMetadata(1, new PropertyChangedCallback(PrintOptionsChanged)));

        public static DependencyProperty PrintRangeToProperty =
            DependencyProperty.Register("PrintRangeTo", typeof(int), typeof(DocumentInfo),
            new PropertyMetadata(1, new PropertyChangedCallback(PrintOptionsChanged)));

        public static DependencyProperty PagesPerSheetProperty =
            DependencyProperty.Register("PagesPerSheet", typeof(int), typeof(DocumentInfo),
            new PropertyMetadata(1, new PropertyChangedCallback(PrintOptionsChanged)));

        public static DependencyProperty DuplexProperty =
            DependencyProperty.Register("Duplex", typeof(bool), typeof(DocumentInfo),
            new PropertyMetadata(new PropertyChangedCallback(PrintOptionsChanged)));

        public static DependencyProperty PageCostProperty =
            DependencyProperty.Register("PageCost", typeof(int), typeof(DocumentInfo),
            new PropertyMetadata(40, new PropertyChangedCallback(PrintOptionsChanged)));

        public static DependencyProperty PagesToPrintProperty =
            DependencyProperty.Register("PagesToPrint", typeof(int), typeof(DocumentInfo));

        public static DependencyProperty SheetsToPrintProperty =
            DependencyProperty.Register("SheetsToPrint", typeof(int), typeof(DocumentInfo));


        public static DependencyProperty PrintCostProperty =
            DependencyProperty.Register("PrintCost", typeof(int), typeof(DocumentInfo));

        public string documentPath;
        public string xpsDocumentPath;

        public int PageCount
        {
            get { return (int)GetValue(PageCountProperty); }
            set { SetValue(PageCountProperty, value); }
        }

        public int CurrentPage
        {
            get { return (int)GetValue(CurrentPageProperty); }
            set { if ((value >= 0) && (value < PageCount)) SetValue(CurrentPageProperty, value); }
        }

        public int Copies
        {
            get { return (int)GetValue(CopiesProperty); }
            set { SetValue(CopiesProperty, value); }
        }

        public int PrintRangeFrom
        {
            get { return (int)GetValue(PrintRangeFromProperty); }
            set { SetValue(PrintRangeFromProperty, value); }
        }

        public int PrintRangeTo
        {
            get { return (int)GetValue(PrintRangeToProperty); }
            set { SetValue(PrintRangeToProperty, value); }
        }

        public int PagesPerSheet
        {
            get { return (int)GetValue(PagesPerSheetProperty); }
            set { SetValue(PagesPerSheetProperty, value); }
        }

        public bool Duplex
        {
            get { return (bool)GetValue(DuplexProperty); }
            set { SetValue(DuplexProperty, value); }
        }

        public int PageCost
        {
            get { return (int)GetValue(PageCostProperty); }
            set { SetValue(PageCostProperty, value); }
        }

        public int PagesToPrint
        {
            get { return (int)GetValue(PagesToPrintProperty); }
            set { SetValue(PagesToPrintProperty, value); }
        }

        public int SheetsToPrint
        {
            get { return (int)GetValue(PagesToPrintProperty); }
            set { SetValue(PagesToPrintProperty, value); }
        }

        public int PrintCost
        {
            get { return (int)GetValue(PrintCostProperty); }
            set { SetValue(PrintCostProperty, value); }
        }

        public static void PageCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DocumentInfo o = d as DocumentInfo;
            o.PrintRangeTo = o.PageCount;
        }

        public static void PrintOptionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as DocumentInfo).UpdatePrintCost();
        }

        public void UpdatePrintCost()
        {
            PagesToPrint = 1 + PrintRangeTo - PrintRangeFrom;
            SheetsToPrint = (PagesToPrint + PagesPerSheet - 1) / PagesPerSheet * Copies;
            PrintCost = PageCost * SheetsToPrint;
            Debug.WriteLine("Copies: {0}", Copies);
            Debug.WriteLine("Range: {0}-{1}", PrintRangeFrom, PrintRangeTo);
            Debug.WriteLine("Pages per sheet: {0}", PagesPerSheet);
            Debug.WriteLine("Duplex: {0}", Duplex);
            Debug.WriteLine("Sheets: {0}", SheetsToPrint);
            Debug.WriteLine("Cost: {0}", PrintCost);
        }
    }
}
