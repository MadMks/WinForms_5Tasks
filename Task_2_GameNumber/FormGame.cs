using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_2_GameNumber
{
    public partial class FormGame : Form
    {
        /// <summary>
        /// Диапазон загадываемых чисел.
        /// </summary>
        private const int _range = 10;

        /// <summary>
        /// Список чисел, которые называл Комп.
        /// </summary>
        public List<int> CompNumber { get; set; }
        /// <summary>
        /// Новая игра.
        /// </summary>
        public bool IsNewGame { get; set; }
        /// <summary>
        /// Число отгадано.
        /// </summary>
        public bool IsGuessed { get; set; }
        /// <summary>
        /// Номер Usera.
        /// </summary>
        public int NumberUser { get; set; }
        /// <summary>
        /// Рандом.
        /// </summary>
        public Random Rand { get; set; }
        /// <summary>
        /// Новое число.
        /// </summary>
        public bool IsNewNumber { get; set; }
        /// <summary>
        /// Кол-во попыток.
        /// </summary>
        public int NumberOfAttempts { get; set; }



        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public FormGame()
        {
            InitializeComponent();

            this.Load += FormGame_Load;
        }

        private void FormGame_Load(object sender, EventArgs e)
        {
            CompNumber = new List<int>();
            IsNewGame = true;
            Rand = new Random();
            NumberUser = 0;

            ResetGameParameters();

            StartGame();
        }


        // Методы.


        /// <summary>
        /// Инициализация переменных.
        /// </summary>
        private void InitializingVariables()
        {
            CompNumber = new List<int>();
            IsNewGame = true;
            Rand = new Random();
            NumberUser = 0;

            ResetGameParameters();
        }


        /// <summary>
        /// Сброс параметров игры.
        /// </summary>
        private void ResetGameParameters()
        {
            IsGuessed = false;
            NumberOfAttempts = 0;
            IsNewNumber = true;
        }


        /// <summary>
        /// Старт игры.
        /// </summary>
        private void StartGame()
        {
            while (IsNewGame == true)
            {
                NewGame();
            }
        }


        /// <summary>
        /// Новая игра.
        /// </summary>
        private void NewGame()
        {
            MessageBox.Show($"Загадайте число от 1 до {_range}.", "Игра",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearCompNumber();

            ResetGameParameters();

            ComputerGuesses();
        }


        /// <summary>
        /// Чистка списка названных номеров Компьютером.
        /// </summary>
        private void ClearCompNumber()
        {
            if (CompNumber != null)
            {
                CompNumber.Clear();
            }
        }


        /// <summary>
        /// Компьютер отгадывает.
        /// </summary>
        private void ComputerGuesses()
        {
            while (IsGuessed == false)
            {
                NumberOfAttempts++;    // увеличиваем число попытки.

                ObtainingARandomNumber();

                ProcessTheResult(CompAsksUser());
            }
        }


        /// <summary>
        /// Обработка результата сообщения.
        /// </summary>
        /// <param name="res">Нажатая кнопка.</param>
        private void ProcessTheResult(DialogResult res)
        {
            if (res == DialogResult.Yes)
            {
                ActionWhenYouPressButtonYES();
            }
            else if (res == DialogResult.No)
            {
                ActionWhenYouPressButtonNO();
            }
        }


        /// <summary>
        /// Действия при нажатии на кнопку "Да".
        /// </summary>
        private void ActionWhenYouPressButtonYES()
        {
            IsGuessed = true;

            MessageBox.Show($"Количество попыток: {NumberOfAttempts}",
                "Число отгадано", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            OfferToRepeatTheGame();
        }


        /// <summary>
        /// Предложение повторить игру.
        /// </summary>
        private void OfferToRepeatTheGame()
        {
            if (AskToPlayMore() == DialogResult.No)
            {
                IsNewGame = false;
            }
            else
            {
                IsNewGame = true;
            }
        }


        /// <summary>
        /// Спрашиваем "Повторить игру?".
        /// </summary>
        private DialogResult AskToPlayMore()
        {
            return MessageBox.Show("Сыграть еще раз?",
                "Вопрос",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }


        /// <summary>
        /// Действия при нажатии на кнопку "Нет".
        /// </summary>
        private void ActionWhenYouPressButtonNO()
        {
            if (CompNumber.Count == _range)
            {
                MessageBox.Show("Были предложены все числа", "Конец игры",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                OfferToRepeatTheGame();

                IsGuessed = true;   // комп угадал число, но user нажал "нет".
            }

            IsNewNumber = true; // комп продолжает угадывать.
        }


        /// <summary>
        /// Комп спрашивает Usera (комп угадывает число).
        /// </summary>
        /// <returns>Нажатая кнопка (ответ Usera).</returns>
        private DialogResult CompAsksUser()
        {
            return MessageBox.Show($"Вы загадали число - {NumberUser}",
                "Игра",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }


        /// <summary>
        /// Получение рандомного числа.
        /// </summary>
        private void ObtainingARandomNumber()
        {
            while (IsNewNumber == true)
            {
                NumberUser = Rand.Next(1, _range + 1);    // включительно.

                CheckThePresenceOfANumberInTheListOfNamed();
            }
        }


        /// <summary>
        /// Проверка наличия числа в списке названных.
        /// </summary>
        private void CheckThePresenceOfANumberInTheListOfNamed()
        {
            // Если комп уже называл число
            if (CompNumber.Find(x => x == NumberUser) == NumberUser 
            && CompNumber.Count > 0)
            {
                IsNewNumber = true; // получить новое число.
            }
            else
            {
                IsNewNumber = false;

                CompNumber.Add(NumberUser);
            }
        }


    }
}