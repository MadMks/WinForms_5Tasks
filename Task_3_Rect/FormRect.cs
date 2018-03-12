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
        /// <summary>
        /// Нажат Ctrl.
        /// </summary>
        private bool IsPressedCtrl { get; set; }
        /// <summary>
        /// Координаты мыши.
        /// </summary>
        private MouseCoordinates MouseCoord { get; set; }



        public FormRect()
        {
            InitializeComponent();

            this.Load += FormRect_Load;
        }


        // Обработчики.


        /// <summary>
        /// Обработчик загрузки приложения.
        /// </summary>
        private void FormRect_Load(object sender, EventArgs e)
        {
            this.Text = "Задание 3 - прямоугольник";
            this.Width = 500;
            this.Height = 250;

            IsPressedCtrl = false;
            MouseCoord = new MouseCoordinates();
            MouseCoord.X = 0;
            MouseCoord.Y = 0;

            this.MouseClick += FormRect_MouseClick;
            this.MouseMove += FormRect_MouseMove;
            this.KeyDown += FormRect_KeyDown;
            this.KeyUp += FormRect_KeyUp;
        }


        /// <summary>
        /// Обработчик нажатия клавиши.
        /// </summary>
        private void FormRect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                IsPressedCtrl = true;
            }
        }


        /// <summary>
        /// Обработчик отпускания клавиши.
        /// </summary>
        private void FormRect_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control)
            {
                IsPressedCtrl = false;
            }
        }


        /// <summary>
        /// Обработчик перемещения указателя мыши.
        /// </summary>
        private void FormRect_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsCoordinatesMouseHaveChanged(e) == true)
            {
                this.Text = $"Текущие координаты мыши: X={e.X}, Y={e.Y}";
            }

            // Запомним последние изменения координат мыши.
            MouseCoord.X = e.X;
            MouseCoord.Y = e.Y;
        }

        
        /// <summary>
        /// Обработчик клика мышки.
        /// </summary>
        private void FormRect_MouseClick(object sender, MouseEventArgs e)
        {
            if (IsLeftMouseButtonAndCtrlClick(e))
            {
                this.Close();
            }
            else if (LeftMouseButtonClick(e))
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
            else if (RightMouseButtonClick(e))
            {
                this.Text = "Клиентская область окна: " 
                    + $"Ширина={this.ClientRectangle.Width}, " 
                    + $"Высота={this.ClientRectangle.Height}";
            }
        }


        // Методы.

        
        /// <summary>
        /// Координаты мыши изменились.
        /// </summary>
        /// <returns>true если изменились.</returns>
        private bool IsCoordinatesMouseHaveChanged(MouseEventArgs e)
        {
            if (e.X != MouseCoord.X || e.Y != MouseCoord.Y)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Нажата ЛКМ и CTRL.
        /// </summary>
        /// <param name="e">Событие мыши.</param>
        /// <returns>true если нажаты ЛКМ и Ctrl.</returns>
        private bool IsLeftMouseButtonAndCtrlClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && IsPressedCtrl == true)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Нажата ЛКМ.
        /// </summary>
        /// <param name="e">Событие мыши.</param>
        /// <returns>true если нажата ЛКМ.</returns>
        private bool LeftMouseButtonClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Нажата ПКМ.
        /// </summary>
        /// <param name="e">Событие мыши.</param>
        /// <returns>true если нажата ПКМ.</returns>
        private bool RightMouseButtonClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return true;
            }

            return false;
        }


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