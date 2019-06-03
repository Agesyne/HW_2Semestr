using System;

namespace CalculatingStack
{
    /// <summary>
    /// The class stores methods for calculating expressions
    /// </summary>
    public class StackCalculator
    {
        /// <summary>
        /// Calculate posfix expression
        /// </summary>
        /// <param name="expression">The given postfix expression</param>
        /// <param name="stack">The using type of stack</param>
        public static int CalculatePostfixExpression(string expression, IADSStack stack)
        {
            if (expression == null || stack == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var i in expression)
            {
                if (Char.IsWhiteSpace(i))
                {
                    continue;
                }

                if (Char.IsDigit(i))
                {
                    stack.Push(i - '0');
                }
                else
                {
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
                                stack.Push(operand1 / operand2);
                                break;

                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                    catch (Exception e)
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
        
    }
}
