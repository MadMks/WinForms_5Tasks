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
        private const string Title = "Задание 4 - создание статиков.";

        /// <summary>
        /// Координаты создаваемого статика.
        /// </summary>
        private Rectangle _staticRect;
        /// <summary>
        /// Список созданных статиков.
        /// </summary>
        public List<Label> ListLabels { get; set; }



        public FormCreatStatics()
        {
            InitializeComponent();

            this.Load += FormCreatStatics_Load;
        }



        // Обработчики событий.


        /// <summary>
        /// Обработчик загрузки формы.
        /// </summary>
        private void FormCreatStatics_Load(object sender, EventArgs e)
        {
            this.Text = Title;
            this.Width = 500;
            this.Height = 300;
        
            ListLabels = new List<Label>();

            this.MouseDown += FormCreatStatics_MouseDown;
            this.MouseUp += FormCreatStatics_MouseUp;
            this.MouseDoubleClick += FormCreatStatics_MouseDoubleClick;
        }


        /// <summary>
        /// Обработчик MouseDoubleClick.
        /// </summary>
        private void FormCreatStatics_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CheckForStaticWithAPointAndDeleteStatic(e);
            }
        }


        /// <summary>
        /// Обработчик MouseDown.
        /// </summary>
        private void FormCreatStatics_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _staticRect.X = e.X;
                _staticRect.Y = e.Y;
            }
            else if (e.Button == MouseButtons.Right)
            {
                CheckForStaticWithAPointAndShowMessage(e);
            }
        }


        /// <summary>
        /// Обработчик MouseUp.
        /// </summary>
        private void FormCreatStatics_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _staticRect.Width = e.X - _staticRect.X;
                _staticRect.Height = e.Y - _staticRect.Y;

                if (CoordinatesHaveChanged() == true)
                {
                    CheckingTheSizeAndCreatingAStatics();
                }
                else
                {
                    return;
                }   
            }
        }


        // Методы.


        /// <summary>
        /// Координаты изменились.
        /// </summary>
        /// <returns>true если изменились.</returns>
        private bool CoordinatesHaveChanged()
        {
            if (_staticRect.Width == 0 && _staticRect.Height == 0)
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// Проверка размера и создание статика.
        /// </summary>
        private void CheckingTheSizeAndCreatingAStatics()
        {
            if (IsPermissibleStaticsSize() == true)
            {
                CreateAStatics();
            }
            else
            {
                MessageBox.Show("Статик не может быть меньше\n"
                    + "чем минимальный размер,\nкоторый составляет 10х10",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }


        /// <summary>
        /// Проверка клик над статиком.
        /// Если true, то вывод данных.
        /// </summary>
        /// <param name="e">Параметры события.</param>
        private void CheckForStaticWithAPointAndShowMessage(MouseEventArgs e)
        {
            if (ListLabels.Count > 0)
            {
                for (int i = ListLabels.Count - 1; i >= 0; i--)
                {
                    if (IsClickOnStatic(e, ListLabels[i]) == true)
                    {
                        ShowCoordinatesInTitle(i, ListLabels[i]);
                        return;
                    }
                }

                this.Text = Title;
            }
        }


        /// <summary>
        /// Проверка клика над статиком, и удаление статика.
        /// </summary>
        /// <param name="e">Данные события клика.</param>
        private void CheckForStaticWithAPointAndDeleteStatic(MouseEventArgs e)
        {
            if (ListLabels.Count > 0)
            {
                for (int i = 0; i < ListLabels.Count; i++)
                {
                    if (IsClickOnStatic(e, ListLabels[i]) == true)
                    {
                        this.Controls.Remove(ListLabels[i]);
                        ListLabels.RemoveAt(i);

                        this.Text = Title;

                        return;
                    }
                }
            }
        }


        /// <summary>
        /// Клик мышки на статике.
        /// </summary>
        /// <param name="e">Параметры события.</param>
        /// <param name="label">Статик.</param>
        /// <returns>true если клик был на статике.</returns>
        private bool IsClickOnStatic(MouseEventArgs e, Label label)
        {
            if (
                (e.X >= label.Left) && (e.X <= label.Right) &&
                (e.Y >= label.Top) && (e.Y <= label.Bottom)
                )
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Покажем координаты в заголовке.
        /// </summary>
        /// <param name="i">Индекс (для номера).</param>
        /// <param name="label">Статик.</param>
        private void ShowCoordinatesInTitle(int i, Label label)
        {
            this.Text = $"№: {i + 1}."
                + $" X={label.Left}, Y={label.Top}."
                + $" Ширина: {label.Width}, высота: {label.Height}";
        }


        /// <summary>
        /// Допустимый размер статика (min px).
        /// </summary>
        /// <returns>true если размер min 10х10px</returns>
        private bool IsPermissibleStaticsSize()
        {
            if (_staticRect.Right >= _staticRect.Left + 10
                &&
                _staticRect.Bottom >= _staticRect.Top + 10)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Создание статика.
        /// </summary>
        private void CreateAStatics()
        {
            Label temp = new Label();   // временный статик.
            temp.Location = _staticRect.Location;
            temp.Size = _staticRect.Size;
            temp.BorderStyle = BorderStyle.FixedSingle;
            temp.Enabled = false;

            this.Controls.Add(temp);
            this.Controls[this.Controls.Count - 1].BringToFront();

            // Запишем координаты созданного статика в список.
            ListLabels.Add(temp);
        }


    }
}