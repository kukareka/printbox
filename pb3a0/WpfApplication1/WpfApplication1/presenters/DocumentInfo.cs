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
            new PropertyMetadata(1, new PropertyChangedCallback(PageCountChanged)));
        
        public static DependencyProperty CurrentPageProperty =
            DependencyProperty.Register("CurrentPage", typeof(int), typeof(DocumentInfo));
        
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

        

        public static void PageCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SessionInfo s = (App.Current as App).sessionInfo;
            s.printOptions.PrintRangeTo = s.documentInfo.PageCount;
        }

    }
}
