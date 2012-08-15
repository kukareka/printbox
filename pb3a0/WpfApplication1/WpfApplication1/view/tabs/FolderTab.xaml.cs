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
    /// <summary>
    /// Interaction logic for FolderTab.xaml
    /// </summary>
    public partial class FolderTab : UserControl
    {
        Presenter presenter;

        public FolderTab()
        {
            InitializeComponent();
            this.DataContext = presenter = new Presenter(this, null);
        }

        #region Event handlers
        private void Item_Click(object sender, MouseButtonEventArgs e)
        {
            Presenter.FolderTabFileInfo f = (sender as FrameworkElement).DataContext as Presenter.FolderTabFileInfo;
            if (f.FileType == Presenter.FolderTabFileInfo.TYPE_FOLDER) presenter.CurrentFolder = f.Path;
            else if (f.FileType == Presenter.FolderTabFileInfo.TYPE_FILE_SUPPORTED) (App.Current as App).LoadDocument(f.Path);
            else (App.Current as App).guiManager.Alert("Вибачте, цей тип файлів не підтримується. Його потрібно перетворити у формат DOC, DOCX, RTF або XPS (див. інструкцію).");
        }

        private void Button_Up(object sender, RoutedEventArgs e)
        {
            presenter.CurrentFolder = new DirectoryInfo(presenter.CurrentFolder).Parent.FullName;
        }
        #endregion

        #region FolderTabPresenter
        public class Presenter : DependencyObject
        {
            FolderTab tab;
            public class FolderTabFileInfo
            {
                public const int TYPE_FOLDER = 1;
                public const int TYPE_FILE_SUPPORTED = 2;
                public const int TYPE_FILE_UNSUPPORTED = 3;


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

            public Presenter(FolderTab tab, string folder)
            {
                this.tab = tab;
                this.CurrentFolder = folder;
            }

            #region Properties
            #region CurrentFolder
            public static DependencyProperty CurrentFolderProperty =
                DependencyProperty.Register("CurrentFolder", typeof(string), typeof(Presenter));

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
                        HasParent = dir.Parent != null;
                        foreach (DirectoryInfo subdir in dir.GetDirectories())
                        {
                            try
                            {
                                if (0 == (subdir.Attributes & (FileAttributes.Hidden | FileAttributes.System)))
                                    folderContents.Add(new FolderTabFileInfo(FolderTabFileInfo.TYPE_FOLDER,
                                        subdir.Name, subdir.FullName, (ImageSource)tab.FindResource("folderIcon")));
                            }
                            catch (Exception)
                            {
                            }                        
                        }

                        List<FolderTabFileInfo> unsupportedFiles = new List<FolderTabFileInfo>();

                        foreach (FileInfo fi in dir.GetFiles())
                        {
                            if ((App.Current as App).xpsWrapper.IsSupportedExtension(fi.Extension))
                                folderContents.Add(new FolderTabFileInfo(FolderTabFileInfo.TYPE_FILE_SUPPORTED,
                                    fi.Name, fi.FullName, (ImageSource)tab.FindResource("documentSupportedIcon")));
                            else unsupportedFiles.Add(new FolderTabFileInfo(FolderTabFileInfo.TYPE_FILE_UNSUPPORTED,
                                    fi.Name, fi.FullName, (ImageSource)tab.FindResource("documentUnsupportedIcon")));
                        }

                        foreach (FolderTabFileInfo f in unsupportedFiles) folderContents.Add(f);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            #endregion

            #region HasParent
            public static DependencyProperty HasParentProperty =
                DependencyProperty.Register("HasParent", typeof(bool), typeof(Presenter));

            public bool HasParent
            {
                get { return (bool)GetValue(HasParentProperty); }
                set { SetValue(HasParentProperty, value); }
            }
            #endregion

            #region FolderContents
            public ObservableCollection<FolderTabFileInfo> folderContents = new ObservableCollection<FolderTabFileInfo>();

            public ObservableCollection<FolderTabFileInfo> FolderContents
            {
                get
                {
                    return folderContents;
                }
            }
            #endregion
            #endregion
        }
        #endregion
    }    
}
