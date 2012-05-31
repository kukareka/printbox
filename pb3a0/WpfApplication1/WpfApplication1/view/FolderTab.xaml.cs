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
using System.ComponentModel;

namespace WpfApplication1
{
    public class FolderTabPresenter : DependencyObject
    {
        public class FolderTabFileInfo
        {
            public const int TYPE_FOLDER = 1;
            public const int TYPE_FILE = 2;

            public FolderTabFileInfo(int type, string name, string path, ImageSource icon)
            {
                this.FileType = type;
                Name = name;
                Path = path;
                Icon = icon;
            }
            public int FileType { get; set; }
            public string Name { get; set; }
            public string Path { get; set; }
            public ImageSource Icon { get; set; }
        }

        public FolderTabPresenter(string folder)
        {
            this.CurrentFolder = folder;
        }



        public static DependencyProperty CurrentFolderProperty =
            DependencyProperty.Register("CurrentFolder", typeof(string), typeof(FolderTabPresenter));

        public ObservableCollection<FolderTabFileInfo> folderContents = new ObservableCollection<FolderTabFileInfo>();

        public ObservableCollection<FolderTabFileInfo> FolderContents
        {
            get
            {
                return folderContents;
            }
        }

        public string CurrentFolder
        {
            get { return (string)GetValue(CurrentFolderProperty); }
            set
            {
                string currentFolder = value;
                SetValue(CurrentFolderProperty, value);
                folderContents.Clear();
                if (DesignerProperties.GetIsInDesignMode(this)) return;
                
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(currentFolder);
                    foreach (DirectoryInfo subdir in dir.GetDirectories())
                    {
                        try
                        {
                            if (0 == (subdir.Attributes & (FileAttributes.Hidden | FileAttributes.System)))
                                folderContents.Add(new FolderTabFileInfo(FolderTabFileInfo.TYPE_FOLDER,
                                    subdir.Name, subdir.FullName, (ImageSource)App.Current.FindResource("folderIcon")));
                        }
                        catch (Exception)
                        {
                        }
                    }
                    foreach (FileInfo fi in dir.GetFiles())
                    {
                        if ((App.Current as App).IsSupportedExtension(fi.Extension))
                            folderContents.Add(new FolderTabFileInfo(FolderTabFileInfo.TYPE_FILE,
                                fi.Name, fi.FullName, (ImageSource)App.Current.FindResource("documentIcon")));
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }

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
