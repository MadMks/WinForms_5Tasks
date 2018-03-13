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
        //private RectCoordinates rect { get; set; }
        /// <summary>
        /// Координаты создаваемого статика.
        /// </summary>
        private Rectangle _staticRect;
        //public Rectangle StaticRect { get; private set; }

        //public List<Rectangle> ListStatics { get; set; }
        public List<Label> ListLabels { get; set; }

        public FormCreatStatics()
        {
            InitializeComponent();

            this.Load += FormCreatStatics_Load;
        }

        private void FormCreatStatics_Load(object sender, EventArgs e)
        {
            this.Text = Title;
            this.Width = 500;
            this.Height = 300;
            //_staticRect = new Rectangle();
            ListLabels = new List<Label>();

            this.MouseDown += FormCreatStatics_MouseDown;
            this.MouseUp += FormCreatStatics_MouseUp;
            this.MouseDoubleClick += FormCreatStatics_MouseDoubleClick;
        }

        private void FormCreatStatics_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                CheckForStaticWithAPointAndDeleteStatic(e);
            }
        }

        

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

        private void FormCreatStatics_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _staticRect.Width = e.X - _staticRect.X;
                _staticRect.Height = e.Y - _staticRect.Y;

                CheckingTheSizeAndCreatingAStatics();
            }
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
                        ListLabels.RemoveAt(i);
                    }
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="label"></param>
        /// <returns></returns>
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

        private void CreateAStatics()
        {
            Label temp = new Label();
            temp.Location = _staticRect.Location;
            temp.Size = _staticRect.Size;
            temp.BorderStyle = BorderStyle.FixedSingle;

            //temp.MouseDown += this.FormCreatStatics_MouseDown;
            //temp.MouseUp += this.FormCreatStatics_MouseUp;

            temp.Enabled = false;
            // создать
            //ListLabels.Add(temp);
            this.Controls.Add(temp);
            this.Controls[this.Controls.Count - 1].BringToFront();
            //this.Controls[this.Controls.Count - 1].Update();
            //this.Controls[this.Controls.Count - 1].Enabled = false;
            //this.Controls[this.Controls.Count - 1].MouseDown
            //    += this.FormCreatStatics_MouseDown;
            //this.Controls[this.Controls.Count - 1].MouseUp
            //    += this.FormCreatStatics_MouseUp;

            // Запишем координаты созданного статика в список.
            //ListStatics.Add(_staticRect);
            ListLabels.Add(temp);
            //ListLabels[ListLabels.Count - 1].MouseDown
            //    += this.FormCreatStatics_MouseDown;
            //ListLabels[ListLabels.Count - 1].MouseUp
            //    += this.FormCreatStatics_MouseUp;
        }
    }
}
