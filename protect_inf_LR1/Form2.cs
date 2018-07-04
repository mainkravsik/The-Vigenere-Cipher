using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace protect_inf_LR1
{
    public partial class Form2 : Form
    {
        private Form1 _form1;
        public Form2(Form1 form1)
        {
            _form1 = form1;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            _form1.Visible = true;
        }
        private int mousex = 0; private int mousey = 0;
        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            mousex = e.X; mousey = e.Y;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - mousex), this.Location.Y + (e.Y - mousey));

            }
        }
    }
}
