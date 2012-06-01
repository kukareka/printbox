using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WordViewDemo
{
    public partial class Form1 : Form
    {
        [DllImport("WordViewWrapper.dll", EntryPoint = "EmbedWord")]
        public static extern bool EmbedWord(IntPtr which);

        public Form1()
        {
            InitializeComponent();
            EmbedWord(panel1.Handle);            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmbedWord(panel1.Handle);                        
        }
    }
}
