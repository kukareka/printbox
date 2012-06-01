using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Diagnostics;

namespace WpfApplication1
{
    public class PrintOptions : DependencyObject
    {
        #region Properties
        #region Copies
        public static DependencyProperty CopiesProperty =
            DependencyProperty.Register("Copies", typeof(int), typeof(PrintOptions),
            new PropertyMetadata(1, new PropertyChangedCallback(PrintOptionsChanged)));

        public int Copies
        {
            get { return (int)GetValue(CopiesProperty); }
            set { SetValue(CopiesProperty, value); }
        }
        #endregion

        #region PrintRangeFrom
        public static DependencyProperty PrintRangeFromProperty =
            DependencyProperty.Register("PrintRangeFrom", typeof(int), typeof(PrintOptions),
            new PropertyMetadata(1, new PropertyChangedCallback(PrintOptionsChanged)));

        public int PrintRangeFrom
        {
            get { return (int)GetValue(PrintRangeFromProperty); }
            set { SetValue(PrintRangeFromProperty, value); }
        }
        #endregion

        #region PrintRangeTo
        public static DependencyProperty PrintRangeToProperty =
            DependencyProperty.Register("PrintRangeTo", typeof(int), typeof(PrintOptions),
            new PropertyMetadata(1, new PropertyChangedCallback(PrintOptionsChanged)));

        public int PrintRangeTo
        {
            get { return (int)GetValue(PrintRangeToProperty); }
            set { SetValue(PrintRangeToProperty, value); }
        }
        #endregion

        #region PagesPerSheet
        public static DependencyProperty PagesPerSheetProperty =
            DependencyProperty.Register("PagesPerSheet", typeof(int), typeof(PrintOptions),
            new PropertyMetadata(1, new PropertyChangedCallback(PrintOptionsChanged)));

        public int PagesPerSheet
        {
            get { return (int)GetValue(PagesPerSheetProperty); }
            set { SetValue(PagesPerSheetProperty, value); }
        }
        #endregion

        #region Duplex
        public static DependencyProperty DuplexProperty =
            DependencyProperty.Register("Duplex", typeof(bool), typeof(PrintOptions),
            new PropertyMetadata(new PropertyChangedCallback(PrintOptionsChanged)));

        public bool Duplex
        {
            get { return (bool)GetValue(DuplexProperty); }
            set { SetValue(DuplexProperty, value); }
        }
        #endregion

        #region PageCost
        public static DependencyProperty PageCostProperty =
            DependencyProperty.Register("PageCost", typeof(int), typeof(PrintOptions),
            new PropertyMetadata(40, new PropertyChangedCallback(PrintOptionsChanged)));

        public int PageCost
        {
            get { return (int)GetValue(PageCostProperty); }
            set { SetValue(PageCostProperty, value); }
        }
        #endregion

        #region PagesToPrint
        public static DependencyProperty PagesToPrintProperty =
            DependencyProperty.Register("PagesToPrint", typeof(int), typeof(PrintOptions));

        public int PagesToPrint
        {
            get { return (int)GetValue(PagesToPrintProperty); }
            set { SetValue(PagesToPrintProperty, value); }
        }
        #endregion

        #region SheetsToPrint
        public static DependencyProperty SheetsToPrintProperty =
            DependencyProperty.Register("SheetsToPrint", typeof(int), typeof(PrintOptions));

        public int SheetsToPrint
        {
            get { return (int)GetValue(PagesToPrintProperty); }
            set { SetValue(PagesToPrintProperty, value); }
        }
        #endregion

        #region PrintCost
        public static DependencyProperty PrintCostProperty =
            DependencyProperty.Register("PrintCost", typeof(int), typeof(PrintOptions));

        public int PrintCost
        {
            get { return (int)GetValue(PrintCostProperty); }
            set { SetValue(PrintCostProperty, value); }
        }
        #endregion
        #endregion

        #region Event handlers
        #region PrintOptionsChanged
        public static void PrintOptionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as PrintOptions).OnPrintOptionsChanged();
        }

        public void OnPrintOptionsChanged()
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
        #endregion
        #endregion
    }
}
