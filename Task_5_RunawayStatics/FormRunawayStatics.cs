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
            if (IsMouseIsCloseToStatic() == true)
            {

            }
        }

        private bool IsMouseIsCloseToStatic()
        {
            throw new NotImplementedException();
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
