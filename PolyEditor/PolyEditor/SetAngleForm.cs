using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyEditor
{
    public partial class SetAngleForm : Form
    {
        public double Angle { get; set; }

        public SetAngleForm(double angle)
        {
            InitializeComponent();
            numericUpDown1.Value = (int)angle;
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                Angle = (int)numericUpDown1.Value;
                this.Close();
            }
        }
    }
}
