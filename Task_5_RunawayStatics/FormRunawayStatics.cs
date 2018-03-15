using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


// NOTE: Для определения куда переместить статик рандомно,
// образно разбил форму на четыре квадрата (Quadrant)
/*  Пример расположения:
 1 2
 3 4 
    */
// Для более лучшего эффекта
// форму можно разбить образно на 16 квадратов.



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
        /// <summary>
        /// Убегающий статик.
        /// </summary>
        private Label _labelStatic;
        /// <summary>
        /// Рандомное число, для рандомного выбора перемещения.
        /// </summary>
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
                MotionWhenApproachingTheWall();

                MovementsInDifferentDirections(e);
            }
        }


        // Методы.


        /// <summary>
        /// Движение при приближении к стенке.
        /// </summary>
        private void MotionWhenApproachingTheWall()
        {
            if (IsStaticsCloseToOneOfTheWalls() == true)
            {
                MoveRandomly();
            }
        }


        /// <summary>
        /// Статик близко к одной из стенок.
        /// </summary>
        /// <returns>true если близко.</returns>
        private bool IsStaticsCloseToOneOfTheWalls()
        {
            if (IsCloseToTheLeftWall() == true
                || IsCloseToTheTopWall() == true
                || IsCloseToTheRightWall() == true
                || IsCloseToTheBottomWall() == true)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Статик близко к нижней стенке.
        /// </summary>
        /// <returns>true если близко.</returns>
        private bool IsCloseToTheBottomWall()
        {
            if (_labelStatic.Bottom > this.ClientRectangle.Bottom - _indentForm)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Статик близко к правой стенке.
        /// </summary>
        /// <returns>true если близко.</returns>
        private bool IsCloseToTheRightWall()
        {
            if (_labelStatic.Right > this.ClientRectangle.Right - _indentForm)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Статик близко к верхней стенке.
        /// </summary>
        /// <returns>true если близко.</returns>
        private bool IsCloseToTheTopWall()
        {
            if (_labelStatic.Top < this.ClientRectangle.Top + _indentForm)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Статик близко к левой стенке.
        /// </summary>
        /// <returns>true если близко.</returns>
        private bool IsCloseToTheLeftWall()
        {
            if (_labelStatic.Left < this.ClientRectangle.Left + _indentForm)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Движения в разных направлениях.
        /// </summary>
        /// <param name="e">Параметры события.</param>
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
                MoveUp();
                MoveRight();
            }
            else if (IsLeftAndTopOfTheStatic(e) == true)
            {
                MoveRight();
                MoveDown();
            }
            else if (IsRightAndTopOfTheStatic(e) == true)
            {
                MoveLeft();
                MoveDown();
            }
            else if (IsRightAndBottomOfTheStatic(e) == true)
            {
                MoveLeft();
                MoveUp();
            }
        }


        /// <summary>
        /// Справа и снизу от статика.
        /// </summary>
        /// <param name="e">Параметры события.</param>
        /// <returns>true если справа и снизу.</returns>
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


        /// <summary>
        /// Справа и сверху от статика.
        /// </summary>
        /// <param name="e">Параметры события.</param>
        /// <returns>true если справа и сверху.</returns>
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


        /// <summary>
        /// Слева и сверху от статика.
        /// </summary>
        /// <param name="e">Параметры события.</param>
        /// <returns>true если слева и сверху.</returns>
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


        /// <summary>
        /// Слева и снизу от статика.
        /// </summary>
        /// <param name="e">Параметры события.</param>
        /// <returns>true если слева и снизу.</returns>
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


        /// <summary>
        /// Снизу от статика.
        /// </summary>
        /// <param name="e">Параметры события.</param>
        /// <returns>true если снизу.</returns>
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


        /// <summary>
        /// Сверху от статика.
        /// </summary>
        /// <param name="e">Параметры события.</param>
        /// <returns>true если сверху.</returns>
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


        /// <summary>
        /// Справа от статика.
        /// </summary>
        /// <param name="e">Параметры события.</param>
        /// <returns>true если справа.</returns>
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


        /// <summary>
        /// Слева от статика.
        /// </summary>
        /// <param name="e">Параметры события.</param>
        /// <returns>true если слева.</returns>
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


        /// <summary>
        /// Рандомное перемещение.
        /// </summary>
        private void MoveRandomly()
        {
            switch (_rand.Next(1, 5))
            {
                case 1:
                    _labelStatic.Location =  MoveToTheFirstQuadrant();
                    break;
                case 2:
                    _labelStatic.Location = MoveToTheSecondQuadrant();
                    break;
                case 3:
                    _labelStatic.Location = MoveToTheThirdQuadrant();
                    break;
                case 4:
                    _labelStatic.Location = MoveToTheFourthQuadrant();
                    break;
                default:
                    MessageBox.Show("Error \"switch\"", "Внимание!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }


        /// <summary>
        /// Получение точки для перемещения в "четвертый квадрат".
        /// </summary>
        /// <returns>Координаты точки назначения.</returns>
        private Point MoveToTheFourthQuadrant()
        {
            Point temp = new Point();

            temp.X =
                ((this.ClientRectangle.Width / 2) + (this.ClientRectangle.Width / 4))
                - (_sizeStatic / 2);
            temp.Y =
                ((this.ClientRectangle.Height / 2) + (this.ClientRectangle.Height / 4))
                - (_sizeStatic / 2);

            return temp;
        }


        /// <summary>
        /// Получение точки для перемещения в "третий квадрат".
        /// </summary>
        /// <returns>Координаты точки назначения.</returns>
        private Point MoveToTheThirdQuadrant()
        {
            Point temp = new Point();

            temp.X =
                ((this.ClientRectangle.Width / 2) / 2)
                - (_sizeStatic / 2);
            temp.Y =
                ((this.ClientRectangle.Height / 2) + (this.ClientRectangle.Height / 4))
                - (_sizeStatic / 2);

            return temp;
        }


        /// <summary>
        /// Получение точки для перемещения в "второй квадрат".
        /// </summary>
        /// <returns>Координаты точки назначения.</returns>
        private Point MoveToTheSecondQuadrant()
        {
            Point temp = new Point();

            temp.X =
                ((this.ClientRectangle.Width / 2) + (this.ClientRectangle.Width / 4))
                - (_sizeStatic / 2);
            temp.Y =
                ((this.ClientRectangle.Height / 2) / 2) - (_sizeStatic / 2);

            return temp;
        }


        /// <summary>
        /// Получение точки для перемещения в "первый квадрат".
        /// </summary>
        /// <returns>Координаты точки назначения.</returns>
        private Point MoveToTheFirstQuadrant()
        {
            Point temp = new Point();

            temp.X = 
                ((this.ClientRectangle.Width / 2) / 2) - (_sizeStatic / 2);
            temp.Y =
                ((this.ClientRectangle.Height / 2) / 2) - (_sizeStatic / 2);

            return temp;
        }


        /// <summary>
        /// Переместить вверх (на 1px).
        /// </summary>
        private void MoveUp()
        {
            _labelStatic.Top--;
        }


        /// <summary>
        /// Переместить вниз (на 1px).
        /// </summary>
        private void MoveDown()
        {
            _labelStatic.Top++;
        }


        /// <summary>
        /// Переместить влево (на 1px).
        /// </summary>
        private void MoveLeft()
        {
            _labelStatic.Left--;
        }


        /// <summary>
        /// Переместить вправо (на 1px).
        /// </summary>
        private void MoveRight()
        {
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