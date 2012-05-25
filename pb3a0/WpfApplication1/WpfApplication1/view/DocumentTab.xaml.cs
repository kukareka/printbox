using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for DocumentTab.xaml
    /// </summary>
    public partial class DocumentTab : UserControl
    {
        App app = Application.Current as App;

        public DocumentTab()
        {
            InitializeComponent();
        }

        private void PageUpButton_Click(object sender, RoutedEventArgs e)
        {
            app.sessionInfo.documentInfo.CurrentPage--;
        }

        private void PageDownButton_Click(object sender, RoutedEventArgs e)
        {
            app.sessionInfo.documentInfo.CurrentPage++;
        }

        private void PagesPerSheetChecked(object sender, RoutedEventArgs e)
        {
            app.sessionInfo.printOptions.PagesPerSheet = Int32.Parse((sender as RadioButton).Content.ToString());
        }

        private void DuplexChecked(object sender, RoutedEventArgs e)
        {
            app.sessionInfo.printOptions.Duplex = sender.Equals(RadioTwoSide);
        }

        public void LoadDocument()
        {
            pageView.DocumentPaginator = app.xpsDocument.GetFixedDocumentSequence().DocumentPaginator;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            DocPanel.IsEnabled = false;
            authPanel.Visibility = Visibility.Visible;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            (app.MainWindow as WpfApplication1.MainWindow).ShowFolders();
        }
    }
}
