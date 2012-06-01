using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using PrintBox;
using log4net;
using PrintBox.Logic.Wrappers;

namespace PrintBox.UserControls
{
    public partial class OpenFileView : UserControl
    {
        private ILog log = LogManager.GetLogger(typeof(OpenFileView));

        private string currentDocPath;

        public OpenFileView()
        {
            InitializeComponent();
        }

        public bool OpenDirectory(string path)
        {
            if (path.Length < 3) path += "\\";
            if (Directory.Exists(path)) currentDocPath = path; //else refresh current
            else if (!Directory.Exists(currentDocPath)) return false;

            try
            {
                List<ListViewItem> items = new List<ListViewItem>();
                btnUpper.Visible = currentDocPath.Length > 3;
                ListViewItem item = null;
                txtAddressLine.Text = currentDocPath;
                DirectoryInfo dInfo = new DirectoryInfo(currentDocPath);
                DirectoryInfo[] directories = dInfo.GetDirectories();
                int length = directories.Length;
                for (int i = 0; i < length; i++)
                {
                    if ((directories[i].Attributes & (FileAttributes.System | FileAttributes.Hidden)) == 0)
                    {
                        item = new ListViewItem(directories[i].Name, 0);
                        item.SubItems.Add("item");
                        items.Add(item);
                    }
                }

                FileInfo[] files = dInfo.GetFiles();
                length = files.Length;
                for (int i = 0; i < length; i++)
                {
                    if ((files[i].Attributes & (FileAttributes.System | FileAttributes.Hidden)) == 0)
                    {
                        string ext = files[i].Extension;
                        int iconIndex = PrintBoxApp.instance.formatManager.GetIconIndex(ext);
                        if (iconIndex > 0)
                        {
                            item = new ListViewItem(files[i].Name, iconIndex);
                            item.SubItems.Add("item");
                            items.Add(item);
                        }
                    }
                }
                SetListViewItems(items);

                if (lvFiles.Items.Count > 96)
                {
                    pnlFilesList.Width = pnlMain.Width - 2 * pnlFilesList.Left - 90;
                    lvFiles.Width = pnlFilesList.Width - 2 * lvFiles.Left;
                    btnScrollUp.Visible = true;
                    btnScrollUp.Left = pnlFilesList.Right + 15;
                    btnScrollUp.Top = pnlFilesList.Top;
                    btnScrollDown.Visible = true;
                    btnScrollDown.Left = pnlFilesList.Right + 15;
                    btnScrollDown.Top = pnlFilesList.Bottom - 78;
                }
                else
                {
                    pnlFilesList.Width = pnlMain.Width - 2 * pnlFilesList.Left;
                    lvFiles.Width = pnlFilesList.Width - 2 * lvFiles.Left;
                    btnScrollDown.Visible = false;
                    btnScrollUp.Visible = false;
                }
                return true;
            }
            catch (Exception ex)
            {
                log.Error(ex);
                PrintBoxApp.instance.guiManager.ShowAds();
                return false;
            }
        }

        private void SetListViewItems(List<ListViewItem> items)
        {
            lvFiles.BeginUpdate();
            lvFiles.Items.Clear();
            lvFiles.Items.AddRange(items.ToArray());
            lvFiles.EndUpdate();
        }

        private void btnUpper_Click(object sender, EventArgs e)
        {
            string upperPath = currentDocPath.Substring(0, currentDocPath.LastIndexOf("\\"));
            OpenDirectory(upperPath);
        }

        private void btnScrollUp_Click(object sender, EventArgs e)
        {
            WinApi.SendMessage(lvFiles.Handle, (uint)WinApi.WM_VSCROLL, (System.UIntPtr)ScrollEventType.SmallDecrement, (System.IntPtr)0);
        }

        private void btnScrollDown_Click(object sender, EventArgs e)
        {
            WinApi.SendMessage(lvFiles.Handle, (uint)WinApi.WM_VSCROLL, (System.UIntPtr)ScrollEventType.SmallIncrement, (System.IntPtr)0);
        }

        private void lvFiles_Layout(object sender, LayoutEventArgs e)
        {
            WinApi.ShowScrollBar(lvFiles.Handle, (int)WinApi.SB_VERT, false);
        }

        private void lvFiles_ListSelectionChanged(object sender, CustomListViewSelectionChangedEventArgs e)
        {
            if (e.Selected.Count > 0)
            {
                ListViewItem item = e.Selected[0];
                lvFiles.DeselectItems();
                if (item != null)
                {
                    this.Enabled = false;
                    Application.DoEvents();
                    string fullPath = currentDocPath;
                    if (!fullPath.EndsWith("\\")) fullPath += "\\";
                    fullPath += Path.GetFileName(item.Text);
                    string ext = Path.GetExtension(item.Text);
                    if (Directory.Exists(fullPath))
                    {
                        OpenDirectory(fullPath);
                    }
                    else if (File.Exists(fullPath))
                    {
                        PrintBoxApp.instance.LoadDocument(fullPath);
                    }
                    this.Enabled = true;
                }
            }
        }


    }

    public class CustomListView : ListView
    {
        public event EventHandler<CustomListViewSelectionChangedEventArgs> ListSelectionChanged;
        private List<ListViewItem> selectedItems = new List<ListViewItem>();

        public void SelectItems(IEnumerable<ListViewItem> items)
        {
            List<ListViewItem> newSelection = new List<ListViewItem>(SelectedItems.Count);
            foreach (ListViewItem item in items)
                newSelection.Add(item);

            List<ListViewItem> selected = new List<ListViewItem>(newSelection.GetRange(0, newSelection.Count));
            foreach (ListViewItem item in selectedItems)
                selected.Remove(item);

            List<ListViewItem> deselected = new List<ListViewItem>(selectedItems.GetRange(0, selectedItems.Count));
            foreach (ListViewItem item in newSelection)
                deselected.Remove(item);

            foreach (ListViewItem item in selected)
                item.Selected = true;

            foreach (ListViewItem item in deselected)
                item.Selected = false;

            selectedItems = newSelection;
            if (selected.Count > 0 || deselected.Count > 0)
            {
                OnListSelectionChanged(new CustomListViewSelectionChangedEventArgs(deselected.AsReadOnly(), selected.AsReadOnly()));
            }
        }

        public void DeselectItems()
        {
            selectedItems = new List<ListViewItem>();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            CheckSelectionChanges();
            base.OnMouseUp(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            CheckSelectionChanges();
            base.OnKeyUp(e);
        }

        protected virtual void OnListSelectionChanged(CustomListViewSelectionChangedEventArgs args)
        {
            if (ListSelectionChanged != null)
            {
                ListSelectionChanged(this, args);
            }
        }

        private void CheckSelectionChanges()
        {
            List<ListViewItem> newSelection = new List<ListViewItem>(SelectedItems.Count);
            foreach (ListViewItem item in SelectedItems)
                newSelection.Add(item);

            List<ListViewItem> selected = new List<ListViewItem>(newSelection.GetRange(0, newSelection.Count));
            foreach (ListViewItem item in selectedItems)
                selected.Remove(item);

            List<ListViewItem> deselected = new List<ListViewItem>(selectedItems.GetRange(0, selectedItems.Count));
            foreach (ListViewItem item in newSelection)
                deselected.Remove(item);

            selectedItems = newSelection;
            if (selected.Count > 0 || deselected.Count > 0)
            {
                OnListSelectionChanged(new CustomListViewSelectionChangedEventArgs(deselected, selected));
            }
        }
    }

    public class CustomListViewSelectionChangedEventArgs : EventArgs
    {
        public IList<ListViewItem> Selected
        {
            get;
            private set;
        }

        public IList<ListViewItem> Deselected
        {
            get;
            private set;
        }

        public CustomListViewSelectionChangedEventArgs(IList<ListViewItem> deselected, IList<ListViewItem> selected)
        {
            Deselected = deselected;
            Selected = selected;
        }
    }
}
