using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMouse
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            game g = new game();
            g.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            rules r = new rules();
            r.ShowDialog();
        }
    }
}
