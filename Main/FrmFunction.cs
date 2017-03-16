using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Main
{
    public partial class FrmFunction : Form
    {
        public FrmFunction()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAdd fa = new FrmAdd();
            fa.Show();
            this.Hide();
        }
    }
}