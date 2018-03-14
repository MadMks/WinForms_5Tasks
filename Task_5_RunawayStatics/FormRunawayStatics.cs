using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_5_RunawayStatics
{
    public partial class FormRunawayStatics : Form
    {
        private const string Title = "Задание 5 - убегающий статик.";

        /// <summary>
        /// Поле вокруг статика (которое не может пересекать статик).
        /// </summary>
        private const int _aroundTheStaics = 75;
        /// <summary>
        /// Размер статика.
        /// </summary>
        private const int _sizeStatic = 25;
        /// <summary>
        /// Отступ от формы (который не может пересекать статик).
        /// </summary>
        private const int _indentForm = 5;

        private Label _labelStatic;

        private Random _rand;


        public FormRunawayStatics()
        {
            InitializeComponent();

            this.Load += FormRunawayStatics_Load;
            this.MouseMove += FormRunawayStatics_MouseMove;
        }
        

        // Обработчики событий.


        /// <summary>
        ///  Обработчик загрузки формы.
        /// </summary>
        private void FormRunawayStatics_Load(object sender, EventArgs e)
        {
            _rand = new Random();

            this.Text = Title;
            this.Width = 500;
            this.Height = 300;

            CreateRunawayStatic();
        }


        /// <summary>
        /// Обработчик движения мышки.
        /// </summary>
        private void FormRunawayStatics_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseIsCloseToStatic(e) == true)
            {
                //MessageBox.Show("work");
                // метод двигать
                // или событие

                MotionWhenApproachingTheWall(e);

                //MoveRandomly();
                MovementsInDifferentDirections(e);
            }
        }

        private void MotionWhenApproachingTheWall(MouseEventArgs e)
        {
            if (IsMouseInTheFirstQuadrant(e) == true)
            {
                if (IsCloseToTheLeftWall() == true)
                {
                    MoveDown();
                    MoveRight();
                }
                else if (IsCloseToTheTopWall() == true)
                {
                    MoveRight();
                    MoveDown();
                }
            }
            else if (IsMouseInTheSecondQuadrant(e) == true)
            {
                if (IsCloseToTheRightWall() == true)
                {
                    MoveDown();
                    MoveLeft();
                }
                else if (IsCloseToTheTopWall() == true)
                {
                    MoveLeft();
                    MoveDown();
                }
            }
            else if (IsMouseInTheThirdQuadrant(e) == true)
            {
                if (IsCloseToTheLeftWall() == true)
                {
                    MoveUp();
                    MoveRight();
                }
                else if (IsCloseToTheBottomWall() == true)
                {
                    MoveRight();
                    MoveUp();
                }
            }
            else if (IsMouseInTheFourthQuadrant(e) == true)
            {
                if (IsCloseToTheRightWall() == true)
                {
                    MoveUp();
                    MoveLeft();
                }
                else if (IsCloseToTheBottomWall() == true)
                {
                    MoveLeft();
                    MoveUp();
                }
            }
        }

        private bool IsCloseToTheBottomWall()
        {
            if (_labelStatic.Bottom > this.ClientRectangle.Bottom - _indentForm)
            {
                return true;
            }

            return false;
        }

        private bool IsCloseToTheRightWall()
        {
            if (_labelStatic.Right > this.ClientRectangle.Right - _indentForm)
            {
                return true;
            }

            return false;
        }

        private bool IsCloseToTheTopWall()
        {
            if (_labelStatic.Top < this.ClientRectangle.Top + _indentForm)
            {
                return true;
            }

            return false;
        }

        private bool IsCloseToTheLeftWall()
        {
            if (_labelStatic.Left < this.ClientRectangle.Left + _indentForm)
            {
                return true;
            }

            return false;
        }

        private bool IsMouseInTheFourthQuadrant(MouseEventArgs e)
        {
            if (
                (e.X > (this.ClientRectangle.Width / 2))
                && (e.Y > (this.ClientRectangle.Height / 2))
                )
            {
                return true;
            }

            return false;
        }

        private bool IsMouseInTheThirdQuadrant(MouseEventArgs e)
        {
            if (
                (e.X < (this.ClientRectangle.Width / 2))
                && (e.Y > (this.ClientRectangle.Height / 2))
                )
            {
                return true;
            }

            return false;
        }

        private bool IsMouseInTheSecondQuadrant(MouseEventArgs e)
        {
            if (
                (e.X > (this.ClientRectangle.Width / 2))
                && (e.Y < (this.ClientRectangle.Height / 2))
                )
            {
                return true;
            }

            return false;
        }

        private bool IsMouseInTheFirstQuadrant(MouseEventArgs e)
        {
            if (
                (e.X < (this.ClientRectangle.Width / 2))
                && (e.Y < (this.ClientRectangle.Height / 2))
                )
            {
                return true;
            }

            return false;
        }

        private void MovementsInDifferentDirections(MouseEventArgs e)
        {
            if ( IsLeftOfTheStatic(e) == true)
            {
                MoveRight();
            }
            else if (IsRightOfTheStatic(e) == true)
            {
                MoveLeft();
            }
            else if (IsTopOfTheStatic(e) == true)
            {
                MoveDown();
            }
            else if (IsBottomOfTheStatic(e) == true)
            {
                MoveUp();
            }
            else if (IsLeftAndBottomOfTheStatic(e) == true)
            {
                MoveRandomly(); // TODO по диагонали.
            }
            else if (IsLeftAndTopOfTheStatic(e) == true)
            {
                MoveRandomly();
            }
            else if (IsRightAndTopOfTheStatic(e) == true)
            {
                MoveRandomly();
            }
            else if (IsRightAndBottomOfTheStatic(e) == true)
            {
                MoveRandomly();
            }
        }

        private bool IsRightAndBottomOfTheStatic(MouseEventArgs e)
        {
            if (
                (e.X >= _labelStatic.Right)
                &&
                (e.Y >= _labelStatic.Bottom)
                )
            {
                return true;
            }

            return false;
        }

        private bool IsRightAndTopOfTheStatic(MouseEventArgs e)
        {
            if (
                (e.X >= _labelStatic.Right)
                &&
                (e.Y <= _labelStatic.Top)
                )
            {
                return true;
            }

            return false;
        }

        private bool IsLeftAndTopOfTheStatic(MouseEventArgs e)
        {
            if (
                (e.X <= _labelStatic.Left)
                &&
                (e.Y <= _labelStatic.Top)
                )
            {
                return true;
            }

            return false;
        }

        private bool IsLeftAndBottomOfTheStatic(MouseEventArgs e)
        {
            if (
                (e.X <= _labelStatic.Left)
                &&
                (e.Y >= _labelStatic.Bottom)
                )
            {
                return true;
            }

            return false;
        }

        private bool IsBottomOfTheStatic(MouseEventArgs e)
        {
            if (
                (e.X < _labelStatic.Right)
                &&
                (e.X > _labelStatic.Left)
                &&
                (e.Y > _labelStatic.Top + (_sizeStatic / 2))
                &&
                (e.Y < _labelStatic.Bottom + _aroundTheStaics)
                )
            {
                return true;
            }

            return false;
        }

        private bool IsTopOfTheStatic(MouseEventArgs e)
        {
            if (
                (e.X < _labelStatic.Right)
                &&
                (e.X > _labelStatic.Left)
                &&
                (e.Y > _labelStatic.Top - _aroundTheStaics)
                &&
                (e.Y < _labelStatic.Bottom - (_sizeStatic / 2))
                )
            {
                return true;
            }

            return false;
        }

        private bool IsRightOfTheStatic(MouseEventArgs e)
        {
            if (
                (e.X < _labelStatic.Right + _aroundTheStaics)
                &&
                (e.X > _labelStatic.Left + (_sizeStatic / 2))
                &&
                (e.Y > _labelStatic.Top)
                &&
                (e.Y < _labelStatic.Bottom)
                )
            {
                return true;
            }

            return false;
        }

        private bool IsLeftOfTheStatic(MouseEventArgs e)
        {
            if (
                (e.X > _labelStatic.Left - _aroundTheStaics)
                &&
                (e.X < _labelStatic.Right - (_sizeStatic / 2))
                &&
                (e.Y > _labelStatic.Top)
                &&
                (e.Y < _labelStatic.Bottom)
                )
            {
                return true;
            }

            return false;
        }

        private void MoveRandomly()
        {
            switch (_rand.Next(1, 5))
            {
                case 1:
                    MoveRight();
                    break;
                case 2:
                    MoveLeft();
                    break;
                case 3:
                    MoveDown();
                    break;
                case 4:
                    MoveUp();
                    break;
                default:
                    MessageBox.Show("Error \"switch\"", "Внимание!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void MoveUp()
        {
            _labelStatic.Top--;
        }

        private void MoveDown()
        {
            _labelStatic.Top++;
        }

        private void MoveLeft()
        {
            _labelStatic.Left--;
        }

        private void MoveRight()
        {
            //MoveStatic()
            _labelStatic.Left++;
        }


        /// <summary>
        /// Указатель мыши близко к статику.
        /// </summary>
        /// <param name="e">Параметры события.</param>
        /// <returns>true если близко.</returns>
        private bool IsMouseIsCloseToStatic(MouseEventArgs e)
        {
            if (
                (e.X > (_labelStatic.Left - _aroundTheStaics))
                &&
                (e.X < (_labelStatic.Right + _aroundTheStaics))
                &&
                (e.Y > (_labelStatic.Top - _aroundTheStaics))
                &&
                (e.Y < (_labelStatic.Bottom + _aroundTheStaics))
                )
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Создание убегающего статика.
        /// </summary>
        private void CreateRunawayStatic()
        {
            _labelStatic = new Label();
            _labelStatic.Location = PointOfAppearanceOfStatic();
            _labelStatic.Width = _sizeStatic;
            _labelStatic.Height = _sizeStatic;
            _labelStatic.BackColor = Color.Black;

            this.Controls.Add(_labelStatic);
        }


        /// <summary>
        /// Получение точки появления статика при загрузке.
        /// </summary>
        /// <returns>Координаты появления (точка).</returns>
        private Point PointOfAppearanceOfStatic()
        {
            Point temp = new Point();

            temp.X = (this.ClientRectangle.Width / 2) - (_sizeStatic / 2);
            temp.Y = (this.ClientRectangle.Height / 2) - (_sizeStatic / 2);

            return temp;
        }
    }
}
