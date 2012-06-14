
using System.Windows;
namespace WpfApplication1
{
    public class SessionInfo : DependencyObject
    {
        public DocumentInfo documentInfo { get; set; }
        public PrintOptions printOptions { get; set; }
        public UserInfo userInfo { get; set; }
        public PrintProgress printProgress { get; set; }

        #region CanPrint
        public static DependencyProperty CanPrintProperty =
            DependencyProperty.Register("CanPrint", typeof(bool), typeof(SessionInfo));

        public bool CanPrint
        {
            get { return (bool)GetValue(CanPrintProperty); }
            set { SetValue(CanPrintProperty, value); }
        }
        #endregion

        public SessionInfo()
        {
            documentInfo = new DocumentInfo();
            printOptions = new PrintOptions();
            userInfo = new UserInfo();
            printProgress = new PrintProgress();
        }

        public static void CanPrintChanges(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (App.Current as App).sessionInfo.CanPrint = (App.Current as App).sessionInfo.userInfo.Balance >= (App.Current as App).sessionInfo.printOptions.PrintCost;
        }
    }
}
