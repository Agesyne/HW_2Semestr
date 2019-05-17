using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class BackField : Form
    {
        ThreeSetField[] winCombinations = new ThreeSetField[8];
        bool?[] buttonCondition = new bool?[9];
        bool isXPlayer = true;

        /// <summary>
        /// Initialise game
        /// </summary>
        public BackField()
        {
            InitializeComponent();
            byte[,] combinations = new byte[8, 3] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, { 2, 4, 6 }, { 0, 4, 8 } };
            for (var i = 0; i < 8; ++i)
            {
                winCombinations[i] = new ThreeSetField(combinations[i, 0], combinations[i, 1], combinations[i, 2]);
            }
        }

        /// <summary>
        /// Change player flag
        /// </summary>
        void ChangePlayer()
        {
            isXPlayer = !isXPlayer;
        }

        /// <summary>
        /// Choose what text button need to have
        /// </summary>
        /// <param name="number">Button number</param>
        /// <returns></returns>
        string ChooseButtonText(byte number)
        {
            if (buttonCondition[number] == null)
            {
                return "";
            }
            else
            {
                return ((bool)buttonCondition[number]? "X" : "O");
            }
        }

        /// <summary>
        /// Check if it's win situation
        /// </summary>
        /// <returns></returns>
        bool CheckIfWin()
        {
            foreach (var i in winCombinations)
            {
                if (i.IsAlreadyWin(buttonCondition, isXPlayer))
                {
                    DialogResult result = MessageBox.Show($"Player {((isXPlayer) ? "X" : "O")} win!\nBegin new Game?", "Game over!", MessageBoxButtons.YesNo);

                    if (result == DialogResult.No)
                    {
                        Environment.Exit(0);
                    }
                    if (result == DialogResult.Yes)
                    {
                        isXPlayer = true;
                        for (byte j = 0; j < 9; ++j)
                        {
                            buttonCondition[j] = null;
                        }
                        Field1.Text = "";
                        Field2.Text = "";
                        Field3.Text = "";
                        Field4.Text = "";
                        Field5.Text = "";
                        Field6.Text = "";
                        Field7.Text = "";
                        Field8.Text = "";
                        Field9.Text = "";
                    }
                    return true;
                }
            }
            bool isStandOff = true;
            foreach (var i in buttonCondition)
            {
                if (i == null)
                {
                    isStandOff = false;
                    break;
                }
            }

            if (isStandOff)
            {
                DialogResult result = MessageBox.Show($"StandOff!\nBegin new Game?", "Game over!", MessageBoxButtons.YesNo);

                if (result == DialogResult.No)
                {
                    Environment.Exit(0);
                }
                if (result == DialogResult.Yes)
                {
                    isXPlayer = true;
                    for (byte j = 0; j < 9; ++j)
                    {
                        buttonCondition[j] = null;
                    }
                    Field1.Text = "";
                    Field2.Text = "";
                    Field3.Text = "";
                    Field4.Text = "";
                    Field5.Text = "";
                    Field6.Text = "";
                    Field7.Text = "";
                    Field8.Text = "";
                    Field9.Text = "";
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Inner class to automatically check win combination
        /// </summary>
        class ThreeSetField
        {
            readonly byte A;
            readonly byte B;
            readonly byte C;

            public ThreeSetField(byte a, byte b, byte c)
            {
                A = a;
                B = b;
                C = c;
            }

            public bool IsAlreadyWin(bool?[] buttonCondition, bool isXPlayer)
            {
                return ((buttonCondition[A] == isXPlayer) && (buttonCondition[B] == isXPlayer) && (buttonCondition[C] == isXPlayer));
            }
        }

        /// <summary>
        /// Button click action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Field7_Click(object sender, EventArgs e)
        {
            if (buttonCondition[6] == null)
            {
                buttonCondition[6] = isXPlayer;
                Field7.Text = ChooseButtonText(6);
                if (!CheckIfWin())
                {
                    ChangePlayer();
                }
                
            }
        }

        /// <summary>
        /// Button click action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Field8_Click(object sender, EventArgs e)
        {
            if (buttonCondition[7] == null)
            {
                buttonCondition[7] = isXPlayer;
                Field8.Text = ChooseButtonText(7);
                if (!CheckIfWin())
                {
                    ChangePlayer();
                }
            }
        }

        /// <summary>
        /// Button click action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Field9_Click(object sender, EventArgs e)
        {
            if (buttonCondition[8] == null)
            {
                buttonCondition[8] = isXPlayer;
                Field9.Text = ChooseButtonText(8);
                if (!CheckIfWin())
                {
                    ChangePlayer();
                }
            }
        }

        /// <summary>
        /// Button click action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Field4_Click(object sender, EventArgs e)
        {
            if (buttonCondition[3] == null)
            {
                buttonCondition[3] = isXPlayer;
                Field4.Text = ChooseButtonText(3);
                if (!CheckIfWin())
                {
                    ChangePlayer();
                }
            }
        }

        /// <summary>
        /// Button click action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Field5_Click(object sender, EventArgs e)
        {
            if (buttonCondition[4] == null)
            {
                buttonCondition[4] = isXPlayer;
                Field5.Text = ChooseButtonText(4);
                if (!CheckIfWin())
                {
                    ChangePlayer();
                }
            }
        }

        /// <summary>
        /// Button click action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Field6_Click(object sender, EventArgs e)
        {
            if (buttonCondition[5] == null)
            {
                buttonCondition[5] = isXPlayer;
                Field6.Text = ChooseButtonText(5);
                if (!CheckIfWin())
                {
                    ChangePlayer();
                }
            }
        }

        /// <summary>
        /// Button click action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Field1_Click(object sender, EventArgs e)
        {
            if (buttonCondition[0] == null)
            {
                buttonCondition[0] = isXPlayer;
                Field1.Text = ChooseButtonText(0);
                if (!CheckIfWin())
                {
                    ChangePlayer();
                }
            }
        }

        /// <summary>
        /// Button click action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Field2_Click(object sender, EventArgs e)
        {
            if (buttonCondition[1] == null)
            {
                buttonCondition[1] = isXPlayer;
                Field2.Text = ChooseButtonText(1);
                if (!CheckIfWin())
                {
                    ChangePlayer();
                }
            }
        }

        /// <summary>
        /// Button click action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Field3_Click(object sender, EventArgs e)
        {
            if (buttonCondition[2] == null)
            {
                buttonCondition[2] = isXPlayer;
                Field3.Text = ChooseButtonText(2);
                if (!CheckIfWin())
                {
                    ChangePlayer();
                }
            }
        }
    }
}
