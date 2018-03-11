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
        }


        /// <summary>
        /// Обработчик клика мышки.
        /// </summary>
        private void FormRect_MouseClick(object sender, MouseEventArgs e)
        {
            if (IsPointOnTheBoundaryOfARectangle(e))
            {
                ShowMessagePointLocation("на границе прямоугольника");
            }
            else if (IsAPointOutsideTheRectangle(e))
            {
                ShowMessagePointLocation("снаружи прямоугольника");
            }
            else if (IsAPointInsideTheRectangle(e))
            {
                ShowMessagePointLocation("внутри прямоугольника");
            }
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
                || (e.X < this.Width - _indent)
                || (e.Y < this.Height - _indent))
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
                || (e.X > this.Width - _indent)
                || (e.Y > this.Height - _indent))
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
                || (e.X == this.Width - _indent)
                || (e.Y == this.Height - _indent))
            {
                return true;
            }

            return false;
        }


    }
}
