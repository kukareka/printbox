using System.Windows.Forms;
using PrintBoxMain;
using PrintBox.Logic.Wrappers;
using PrintBox.Logic;

namespace PrintBox.GUI.Forms
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            WinApi.SuspendDrawing(this);
            InitializeComponent();
            Left = (1280 - Width) / 2;
            Top = (1024 - Height) / 2;
            if (PrintBoxApp.instance.runOptions.topMost) TopMost = true;
            WinApi.ResumeDrawing(this);
        }

        private void LoadingForm_Deactivate(object sender, System.EventArgs e)
        {
            this.Hide();
        }
    }
}
