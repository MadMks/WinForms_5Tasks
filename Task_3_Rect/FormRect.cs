using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_3_Rect
{
    public partial class FormRect : Form
    {
        /// <summary>
        /// Отступ от границ рабочей области формы.
        /// </summary>
        private const int _indent = 10;


        public FormRect()
        {
            InitializeComponent();

            this.Load += FormRect_Load;
        }


        // Обработчики.


        private void FormRect_Load(object sender, EventArgs e)
        {
            this.Text = "Задание 3 - прямоугольник";
            this.Width = 450;
            this.Height = 250;

            this.MouseClick += FormRect_MouseClick;
            this.MouseMove += FormRect_MouseMove;
            this.KeyDown += FormRect_KeyDown;

            //this.
        }

        

        private void FormRect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                MessageBox.Show("Close   !");
            }
            else if (e.Modifiers == Keys.Control)
            {
                //MessageBox.Show("Ctrl");
            }
        }




        /// <summary>
        /// Обработчик перемещения указателя мыши.
        /// </summary>
        private void FormRect_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = $"Текущие координаты мыши: X={e.X}, Y={e.Y}";
        }


        /// <summary>
        /// Обработчик клика мышки.
        /// </summary>
        private void FormRect_MouseClick(object sender, MouseEventArgs e)
        {


            //if (IsLeftMouseButtonAndCtrlClick(e))
            //{
            //    MessageBox.Show("777");

            //}
            //else if (LeftMouseButtonClick(e))
            //{
            //    if (IsPointOnTheBoundaryOfARectangle(e))
            //    {
            //        ShowMessagePointLocation("на границе прямоугольника");
            //    }
            //    else if (IsAPointOutsideTheRectangle(e))
            //    {
            //        ShowMessagePointLocation("снаружи прямоугольника");
            //    }
            //    else if (IsAPointInsideTheRectangle(e))
            //    {
            //        ShowMessagePointLocation("внутри прямоугольника");
            //    }
            //}
            //else if (RightMouseButtonClick(e))
            //{

            //}

        }

        private bool IsLeftMouseButtonAndCtrlClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                return true;
            }

            return false;
        }

        private bool RightMouseButtonClick(MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private bool LeftMouseButtonClick(MouseEventArgs e)
        {
            throw new NotImplementedException();
        }


        // Методы.


        /// <summary>
        /// Вывод сообщения о текущем местоположении точки (мышки).
        /// </summary>
        /// <param name="str">Положение точки относительно прямоугольника
        /// (представленого).</param>
        private void ShowMessagePointLocation(string str)
        {
            MessageBox.Show($"Текущая точка: {str}",
                    "Расположение точки", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }


        /// <summary>
        /// Точка внутри прямоугольника.
        /// </summary>
        /// <returns> true если внутри.</returns>
        private bool IsAPointInsideTheRectangle(MouseEventArgs e)
        {
            if (e.X > _indent || e.Y > _indent
                || e.X < (this.ClientRectangle.Right - _indent)
                || e.Y < (this.ClientRectangle.Bottom - _indent))
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Точка снаружи прямоугольника.
        /// </summary>
        /// <returns> true если снаружи.</returns>
        private bool IsAPointOutsideTheRectangle(MouseEventArgs e)
        {
            if (e.X < _indent || e.Y < _indent
                || e.X > (this.ClientRectangle.Right - _indent)
                || e.Y > (this.ClientRectangle.Bottom - _indent))
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Точка на границе прямоугольника.
        /// </summary>
        /// <returns>true если на границе.</returns>     
        private bool IsPointOnTheBoundaryOfARectangle(MouseEventArgs e)
        {
            if (e.X == _indent || e.Y == _indent
                || e.X == (this.ClientRectangle.Right - _indent)
                || e.Y == (this.ClientRectangle.Bottom - _indent))
            {
                return true;
            }

            return false;
        }


    }
}
