using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_4_CreationOfStatics
{
    public partial class FormCreatStatics : Form
    {
        //private RectCoordinates rect { get; set; }
        //Rectangle rect;
        public Rectangle StaticRect { get; private set; }

        public FormCreatStatics()
        {
            InitializeComponent();

            this.Load += FormCreatStatics_Load;
        }

        private void FormCreatStatics_Load(object sender, EventArgs e)
        {
            StaticRect = new Rectangle();

            this.MouseDown += FormCreatStatics_MouseDown;
            this.MouseUp += FormCreatStatics_MouseUp;
        }

        

        private void FormCreatStatics_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                StaticRect.X = e.X;
                StaticRect.Y = e.Y;
            }
        }

        private void FormCreatStatics_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                rect.Width = e.X - rect.X;
                rect.Height = e.Y - rect.Y;
            }
        }
    }
}
