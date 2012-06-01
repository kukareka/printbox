using System.Windows;
using System.Windows.Xps.Packaging;

namespace WpfApplication1
{
    public class DocumentInfo : DependencyObject
    {
        #region Properties
        #region PageCount
        public static DependencyProperty PageCountProperty =
            DependencyProperty.Register("PageCount", typeof(int), typeof(DocumentInfo),
            new PropertyMetadata(1, new PropertyChangedCallback(PageCountChanged)));

        public int PageCount
        {
            get { return (int)GetValue(PageCountProperty); }
            set { SetValue(PageCountProperty, value); }
        }

        public static void PageCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SessionInfo s = (App.Current as App).sessionInfo;
            s.printOptions.PrintRangeTo = s.documentInfo.PageCount;
        }
        #endregion
        #region CurrentPage
        public static DependencyProperty CurrentPageProperty =
            DependencyProperty.Register("CurrentPage", typeof(int), typeof(DocumentInfo));

        public int CurrentPage
        {
            get { return (int)GetValue(CurrentPageProperty); }
            set { if ((value >= 0) && (value < PageCount)) SetValue(CurrentPageProperty, value); }
        }
        #endregion
        #endregion
        
        public string documentPath;
        public string xpsDocumentPath;
        public XpsDocument xpsDocument = null;
    }
}
