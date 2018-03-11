using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_1_Resume
{
    /// <summary>
    /// Класс резюме.
    /// </summary>
    public partial class Resume : Form
    {
        /// <summary>
        /// Данные резюме.
        /// </summary>
        string[] str = {
                "Lorem ipsum dolor",
                "Lorem",
                "Lorem ipsum"
            };
        /// <summary>
        /// Кол-во символов.
        /// </summary>
        int nQuantitySymbol = 0;



        public Resume()
        {
            InitializeComponent();

            this.Start();
        }


        /// <summary>
        /// Старт вывода Резюме.
        /// </summary>
        private void Start()
        {
            this.ShowResume();

            MessageBox.Show(
                $"Среднее число символов: {ComputeAverage()}",
                "Ответ");
        }


        /// <summary>
        /// Вывод резюме.
        /// </summary>
        private void ShowResume()
        {
            for (int i = 0; i < str.Length; i++)
            {
                nQuantitySymbol += str[i].Length;

                MessageBox.Show(str[i], $"Резюме: {i + 1}");
            }
        }


        /// <summary>
        /// Вычисление среднего числа символов.
        /// </summary>
        /// <returns>Среднее число символов.</returns>
        private int ComputeAverage()
        {
            return nQuantitySymbol / str.Length;
        }
    }
}