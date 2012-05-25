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
using System.Collections.ObjectModel;
using System.IO;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for FolderTab.xaml
    /// </summary>
    public partial class FolderTab : UserControl
    {
        FolderTabPresenter presenter;

        public FolderTab()
        {
            InitializeComponent();
            this.DataContext = presenter = new FolderTabPresenter(@"c:\");
        }

        private void Item_Click(object sender, MouseButtonEventArgs e)
        {
            FolderTabPresenter.FolderTabFileInfo f = (sender as FrameworkElement).DataContext as FolderTabPresenter.FolderTabFileInfo;
            if (f.FileType == FolderTabPresenter.FolderTabFileInfo.TYPE_FOLDER) presenter.CurrentFolder = f.Path;
            else if (f.FileType == FolderTabPresenter.FolderTabFileInfo.TYPE_FILE) (App.Current as App).LoadDocument(f.Path);
        }

        private void Button_Up(object sender, RoutedEventArgs e)
        {
            presenter.CurrentFolder = new DirectoryInfo(presenter.CurrentFolder).Parent.FullName;
        }
    }
}
