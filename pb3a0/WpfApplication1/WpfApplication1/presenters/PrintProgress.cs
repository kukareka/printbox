using System.Windows;

namespace WpfApplication1
{
    public class PrintProgress : DependencyObject
    {
        public enum PrintingStatus {InProgress = 0, Done = 1, Error = -1}

        #region Properties

        #region PagesPrinted
        public static DependencyProperty PagesPrintedProperty =
            DependencyProperty.Register("PagesPrinted", typeof(int), typeof(PrintProgress),
            new PropertyMetadata(0));

        public int PagesPrinted
        {
            get { return (int)GetValue(PagesPrintedProperty); }
            set { SetValue(PagesPrintedProperty, value); }
        }
        #endregion

        #region Status
        public static DependencyProperty StatusProperty =
            DependencyProperty.Register("Status", typeof(PrintingStatus), typeof(PrintProgress),
            new PropertyMetadata(PrintingStatus.Done));

        public PrintingStatus Status
        {
            get { return (PrintingStatus)GetValue(StatusProperty); }
            set { SetValue(StatusProperty, value); }
        }
        #endregion


        #endregion
    }
}
