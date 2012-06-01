using System;
using System.Windows.Forms;
using PrintBoxMain;
using PrintBox.Logic.Wrappers;

namespace PrintBox.GUI.Forms
{
    public partial class InstructionForm : Form
    {
        public InstructionForm()
        {
            WinApi.SuspendDrawing(this);
            InitializeComponent();
            InitPanels();
            LoadInstruction();
            WinApi.ResumeDrawing(this);
        }

        public void InitPanels()
        {
            btnCloseInstruction.Left = (btnCloseInstruction.Parent.Width - btnCloseInstruction.Width) / 2;
        }

        public void LoadInstruction()
        {
            txtInstruction.AddHTML(ResourcesMessages.instructionHTML);
        }

        private void btnCloseInstruction_MouseDown(object sender, MouseEventArgs e)
        {
            this.Hide();
        }

        private void txtInstruction_Enter(object sender, EventArgs e)
        {
            btnCloseInstruction.Focus();
        }
    }
}
