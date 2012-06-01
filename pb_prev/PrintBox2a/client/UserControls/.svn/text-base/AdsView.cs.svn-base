using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PrintBox;

namespace PrintBox.UserControls
{
    public partial class AdsView : UserControl
    {
        public AdsView()
        {
            InitializeComponent();
            LoadParams();
        }

        public void LoadParams()
        {
            try
            {
                lblLine2.Text = String.Format(lblLine2.Text, PrintBoxApp.instance.config.PageCost);

            }
            catch(Exception) {}
        }
    }
}
