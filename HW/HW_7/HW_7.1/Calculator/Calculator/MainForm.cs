using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Background : Form
    {
        /// <summary>
        /// Methods for counting expression
        /// </summary>
        public static class Calculator
        {
            /// <summary>
            /// Get int degree of priority of operation
            /// </summary>
            /// <param name="symbol">The operation</param>
            private static int GetPriority(Char symbol)
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
            
            /// <summary>
            /// Translate infix expression to postfix form
            /// </summary>
            /// <param name="infix">Infix expression</param>
            /// <returns>Postfix expression</returns>
            private static string TranslateToPostfix(string infix)
            {
                var postfix = "";
                var number = "";
                var stack = new Stack<char>();
                stack.Push('#');

                try
                {
                    foreach (var i in infix)
                    {
                        if (Char.IsWhiteSpace(i))
                        {
                            continue;
                        }

                        if (Char.IsDigit(i))
                        {
                            number += i;
                        }
                        else
                        {
                            if (number != "")
                            {
                                postfix += number + " ";
                                number = "";
                            }

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
                                        postfix += stack.Pop() + " ";
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
                                            postfix += stack.Pop() + " ";
                                        }
                                        stack.Push(i);
                                    }
                                }
                            }
                        }
                    }
                    if (number != "")
                    {
                        postfix += number + " ";
                    }

                    while (stack.Peek() != '#')
                    {
                        postfix += stack.Pop() + " ";
                    }
                }
                catch (Exception)
                {
                    throw new ArgumentOutOfRangeException();
                }

                return postfix;
            }
            
            /// <summary>
            /// Count postfix expression
            /// </summary>
            /// <param name="postfix">The expression</param>
            /// <returns>The counted result</returns>
            private static int CountPostfix(string postfix)
            {
                var number = "";
                var stack = new Stack<int>();
                if (postfix == null)
                {
                    throw new ArgumentNullException();
                }

                foreach (var i in postfix)
                {
                    if (Char.IsWhiteSpace(i))
                    {
                        if (number != "")
                        {
                            stack.Push(Convert.ToInt32(number));
                            number = "";
                        }
                        continue;
                    }

                    if (Char.IsDigit(i))
                    {
                        number += i;
                    }
                    else
                    {
                        if (number != "")
                        {
                            stack.Push(Convert.ToInt32(number));
                            number = "";
                        }

                        try
                        {
                            var operand2 = stack.Pop();
                            var operand1 = stack.Pop();
                            switch (i)
                            {
                                case '+':
                                    stack.Push(operand1 + operand2);
                                    break;

                                case '-':
                                    stack.Push(operand1 - operand2);
                                    break;

                                case '*':
                                    stack.Push(operand1 * operand2);
                                    break;

                                case '/':
                                    if (operand2 == 0)
                                    {
                                        throw new DivideByZeroException();
                                    }
                                    stack.Push(operand1 / operand2);
                                    break;

                                case '%':
                                    stack.Push(operand1 % operand2);
                                    break;

                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                        }
                        catch (DivideByZeroException)
                        {
                            throw;
                        }
                        catch (Exception)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                    }
                }

                if (stack.Count != 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return stack.Pop();
            }

            /// <summary>
            /// Count infix expression
            /// </summary>
            /// <param name="infix">The counting exprission</param>
            /// <returns>The counted result</returns>
            public static int Count(string infix)
            {
                string postfix = TranslateToPostfix(infix);
                return CountPostfix(postfix);
            }

        }


        /// <summary>
        /// Constructor: initialize forms
        /// </summary>
        public Background()
        {
            InitializeComponent();
        }
        

        /// <summary>
        /// Add digit to expression
        /// </summary>
        private void NumberButton_Click(object sender, EventArgs e)
        {
            var buttonObject = (Button)sender;
            ExpressionBox.Text += (string)buttonObject.Tag;
        }
        
        /// <summary>
        /// Delete last character from expression
        /// </summary>
        private void BackspaceButton_Click(object sender, EventArgs e)
        {
            if (ExpressionBox.Text.Length != 0)
            {
                ExpressionBox.Text = ExpressionBox.Text.Remove(ExpressionBox.Text.Length - 1);
            }
        }

        /// <summary>
        /// Clear expression box
        /// </summary>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            ExpressionBox.Text = "";
        }

        /// <summary>
        /// Add '(' to expression
        /// </summary>
        private void LeftBracketButton_Click(object sender, EventArgs e)
        {
            ExpressionBox.Text += '(';
        }

        /// <summary>
        /// Add ')' to expression
        /// </summary>
        private void RightBracketButton_Click(object sender, EventArgs e)
        {
            ExpressionBox.Text += ')';
        }


        /// <summary>
        /// Add '0' to expression if it needs
        /// </summary>
        private void PossibyAddZero()
        {
            if (ExpressionBox.Text.Length == 0)
            {
                var ch = ExpressionBox.Text[ExpressionBox.Text.Length - 1];
                if (!Char.IsDigit(ch) && ch != '(' && ch != ')')
                {
                    ExpressionBox.Text += '0';
                }
            }
        }

        /// <summary>
        /// Check if last character is operation
        /// </summary>
        /// <returns></returns>
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
        
        /// <summary>
        /// Add operation to expression
        /// </summary>
        private void OperationButton_Click(object sender, EventArgs e)
        {
            var buttonObject = (Button)sender;
            if (IsLastOperation())
            {
                ExpressionBox.Text = ExpressionBox.Text.Remove(ExpressionBox.Text.Length - 1);
            }
            PossibyAddZero();
            ExpressionBox.Text += (string)buttonObject.Tag;
        }
        

        /// <summary>
        /// Calculate expression
        /// </summary>
        private void CulculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                ResultBox.Text = Convert.ToString(Calculator.Count(ExpressionBox.Text));
            }
            catch (ArgumentOutOfRangeException)
            {

            }
            catch(DivideByZeroException)
            {

            }
        }

    }
}
