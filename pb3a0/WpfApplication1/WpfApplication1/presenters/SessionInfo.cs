
using System.Windows;
namespace WpfApplication1
{
    public class SessionInfo : DependencyObject
    {
        public App app { get { return App.Current as App; } }
        public DocumentInfo documentInfo { get; set; }
        public PrintOptions printOptions { get; set; }
        public UserInfo userInfo { get; set; }
        public PrintProgress printProgress { get; set; }

        public SessionInfo()
        {
            documentInfo = new DocumentInfo();
            printOptions = new PrintOptions();
            userInfo = new UserInfo();
            printProgress = new PrintProgress();
        }
    }
}
