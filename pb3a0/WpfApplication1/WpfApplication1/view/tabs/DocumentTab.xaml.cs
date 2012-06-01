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
        App app = App.Current as App;

        public DocumentTab()
        {            
            InitializeComponent();
        }

        public void LoadDocument()
        {
            pageView.DocumentPaginator = app.sessionInfo.documentInfo.xpsDocument.GetFixedDocumentSequence().DocumentPaginator;
        }

        #region Event handlers
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
            if (!DesignerProperties.GetIsInDesignMode(this))
                app.sessionInfo.printOptions.PagesPerSheet = Int32.Parse((sender as RadioButton).Content.ToString());
        }

        private void DuplexChecked(object sender, RoutedEventArgs e)
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
                app.sessionInfo.printOptions.Duplex = sender.Equals(RadioTwoSide);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            app.AuthAndPrint();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            (app.MainWindow as MainWindow).ShowFolder();
        }
        #endregion
    }
}
