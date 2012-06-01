using System;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for DocumentTab.xaml
    /// </summary>
    public partial class DocumentTab : UserControl
    {
        SessionInfo sessionInfo = (App.Current as App).sessionInfo;

        public DocumentTab()
        {            
            InitializeComponent();
        }

        public void LoadDocument()
        {
            pageView.DocumentPaginator = sessionInfo.documentInfo.xpsDocument.GetFixedDocumentSequence().DocumentPaginator;
        }

        #region Event handlers
        private void PageUpButton_Click(object sender, RoutedEventArgs e)
        {
            sessionInfo.documentInfo.CurrentPage--;
        }

        private void PageDownButton_Click(object sender, RoutedEventArgs e)
        {
            sessionInfo.documentInfo.CurrentPage++;
        }

        private void PagesPerSheetChecked(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this)) return;
            sessionInfo.printOptions.PagesPerSheet = Int32.Parse((sender as RadioButton).Content.ToString());
        }

        private void DuplexChecked(object sender, RoutedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(this)) return;
            sessionInfo.printOptions.Duplex = sender.Equals(RadioTwoSide);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            (App.Current.MainWindow as WpfApplication1.MainWindow).ShowFolders();
        }
        #endregion
    }
}
