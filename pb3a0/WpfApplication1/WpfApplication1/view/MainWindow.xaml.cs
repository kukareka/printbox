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
using System.Windows.Xps.Packaging;
using Microsoft.Win32;
using System.IO;

using System.Diagnostics;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        App app = Application.Current as App;
        
        public MainWindow()
        {
            DataContext = app.sessionInfo;
            InitializeComponent();
            WindowState = System.Windows.WindowState.Maximized;
            (new ControlDialog()).Show();
        }
        
        public void ShowTab(UserControl tab)
        {
            UserControl tts = null;
            foreach (UIElement e in tabs.Children)
            {
                if (e is UserControl)
                {
                    UserControl u = e as UserControl;
                    u.Visibility = Visibility.Hidden;
                    if (tab.Name.Equals(u.Name)) tts = tab;
                }
            }
            if (tts != null) tts.Visibility = Visibility.Visible;
        }

        public void ShowWelcomeTab()
        {
            ShowTab(welcomeTab);
        }

        public void ShowFolder(string folder = null)
        {
            if (folder != null) (folderTab.DataContext as FolderTab.Presenter).CurrentFolder = folder;
            ShowTab(folderTab);        
        }

        public void LoadDocument()
        {
            documentTab.LoadDocument();
            ShowTab(documentTab);
        }

        private void Service_Click(object sender, MouseButtonEventArgs e)
        {
            app.DoService();
        }

        private void Instruction_Click(object sender, RoutedEventArgs e)
        {
            app.guiManager.ShowInstruction();
        }

        #region Event handlers

        #endregion
    }
}
