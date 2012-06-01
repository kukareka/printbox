using System.Drawing;
using System.Windows.Forms;
using PrintBox.Logic.Wrappers;
using PrintBox.Logic;

namespace PrintBox.GUI.Forms
{
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
            WinApi.SuspendDrawing(this);
            InitializeComponent();
            Left = (1280 - Width) / 2;
            Top = (1024 - Height) / 2;
            if (PrintBoxApp.instance.runOptions.topMost) TopMost = true;
            WinApi.ResumeDrawing(this);
        }

        public void SetMessage(Color color, string msg)
        {
            txtMessage.ForeColor = color;
            txtMessage.Text = msg;
        }

        private void btnOk_MouseDown(object sender, MouseEventArgs e)
        {
            this.Hide();
        }

        private void MessageForm_Deactivate(object sender, System.EventArgs e)
        {
            this.Hide();
        }
    }
}
