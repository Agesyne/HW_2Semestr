using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Background : Form
    {
        private class Calculator
        {
            private class Token
            {

            }

            private int GetPriority(Char symbol)
            {
                switch (symbol)
                {
                    case '*':
                    case '/':
                    case '%':
                        return 3;

                    case '+':
                    case '-':
                        return 2;

                    case '(':
                    case ')':
                    case '#':
                        return 1;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            private string TranslateToPostfix(string infix)
            {
                var postfix = "";
                var stack = new Stack<char>();
                stack.Push('#');

                foreach (var i in infix)
                {
                    if (Char.IsWhiteSpace(i))
                    {
                        continue;
                    }

                    if (Char.IsDigit(i))
                    {
                        postfix += i;
                    }
                    else
                    {
                        if (i == '(')
                        {
                            stack.Push('(');
                        }
                        else
                        {
                            if (i == ')')
                            {
                                while (stack.Peek() != '(')
                                {
                                    postfix += stack.Pop();
                                }
                                stack.Pop();
                            }
                            else
                            {
                                if (GetPriority(i) > GetPriority(stack.Peek()))
                                {
                                    stack.Push(i);
                                }
                                else
                                {
                                    while (GetPriority(i) <= GetPriority(stack.Peek()))
                                    {
                                        postfix += stack.Pop();
                                    }
                                    stack.Push(i);
                                }
                            }
                        }
                    }
                }

                while (stack.Peek() != '#')
                {
                    postfix += stack.Pop();
                }

                return postfix;
            }

            private int CountPostfix(string postfix)
            {
                var stack = new Stack<int>();

            }

            public void Count(string infix)
            {
                string postfix = TranslateToPostfix(infix);
                int result = 
            }
        }

        public Background()
        {
            InitializeComponent();
        }

        private void Number0Button_Click(object sender, EventArgs e)
        {
            ExpressionBox.Text += '0';
        }

        private void Number1Button_Click(object sender, EventArgs e)
        {
            ExpressionBox.Text += '1';
        }

        private void Number2Button_Click(object sender, EventArgs e)
        {
            ExpressionBox.Text += '2';
        }

        private void Number3Button_Click(object sender, EventArgs e)
        {
            ExpressionBox.Text += '3';
        }

        private void Number4Button_Click(object sender, EventArgs e)
        {
            ExpressionBox.Text += '4';
        }

        private void Number5Button_Click(object sender, EventArgs e)
        {
            ExpressionBox.Text += '5';
        }

        private void Number6Button_Click(object sender, EventArgs e)
        {
            ExpressionBox.Text += '6';
        }

        private void Number7Button_Click(object sender, EventArgs e)
        {
            ExpressionBox.Text += '7';
        }

        private void Number8Button_Click(object sender, EventArgs e)
        {
            ExpressionBox.Text += '8';
        }

        private void Number9Button_Click(object sender, EventArgs e)
        {
            ExpressionBox.Text += '9';
        }


        private void BackspaceButton_Click(object sender, EventArgs e)
        {
            if (ExpressionBox.Text.Length != 0)
            {
                ExpressionBox.Text = ExpressionBox.Text.Remove(ExpressionBox.Text.Length - 1);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ExpressionBox.Text = "";
        }



        private void LeftBracketButton_Click(object sender, EventArgs e)
        {
            ExpressionBox.Text += '(';
        }

        private void RightBracketButton_Click(object sender, EventArgs e)
        {
            ExpressionBox.Text += ')';
        }


        private void PossibyAddZero()
        {
            if (ExpressionBox.Text.Length == 0 || !Char.IsDigit(ExpressionBox.Text[ExpressionBox.Text.Length - 1]))
            {
                ExpressionBox.Text += '0';
            }
        }

        private bool IsLastOperation()
        {
            if (ExpressionBox.Text.Length == 0)
            {
                return false;
            }

            char ch = ExpressionBox.Text[ExpressionBox.Text.Length - 1];
            bool isLastOperation = ch == '+' 
                                || ch == '-' 
                                || ch == '*' 
                                || ch == '/' 
                                || ch == '%';
            return isLastOperation;
        }

        private void ClickOperation(char operation)
        {
            if (IsLastOperation())
            {
                ExpressionBox.Text = ExpressionBox.Text.Remove(ExpressionBox.Text.Length - 1);
            }
            PossibyAddZero();
            ExpressionBox.Text += operation;
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            ClickOperation('+');
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            ClickOperation('-');
        }

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            ClickOperation('*');
        }

        private void DivideButton_Click(object sender, EventArgs e)
        {
            ClickOperation('/');
        }

        private void RestDivideButton_Click(object sender, EventArgs e)
        {
            ClickOperation('%');
        }

        private void CulculateButton_Click(object sender, EventArgs e)
        {

        }
    }
}
