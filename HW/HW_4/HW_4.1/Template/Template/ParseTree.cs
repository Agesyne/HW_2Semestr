using System;

namespace Structures
{
    /// <summary>
    /// ADS ParseTree
    /// </summary>
    public class ParseTree
    {
        /// <summary>
        /// The element of the tree
        /// </summary>
        private class Node
        {
            /// <summary>
            /// The type of argument: number or operation (which)
            /// </summary>
            private enum TokenType
            {
                 NUM
                ,OP_SUM
                ,OP_SUB
                ,OP_MUL
                ,OP_DIV,
            }

            /// <summary>
            /// The argument of Node: number or operation
            /// </summary>
            private class Token
            {
                /// <summary>
                /// The type of argument
                /// </summary>
                public TokenType Type { get; protected set; }

                /// <summary>
                /// The number value if its type is the same
                /// </summary>
                public int Number { get; protected set; }

                /// <summary>
                /// Constructor for the structure
                /// </summary>
                /// <param name="type"></param>
                /// <param name="number"></param>
                public Token(TokenType type = TokenType.NUM, int number = 0)
                {
                    Type = type;
                    Number = number;
                }

                /// <summary>
                /// To string conventer
                /// </summary>
                /// <returns>String representation of operation or number</returns>
                public override string ToString()
                {
                    if (Type == TokenType.NUM)
                    {
                        return $"{Number}";
                    }
                    else
                    {
                        if (Type == TokenType.OP_SUM)
                        {
                            return "+";
                        }
                        else if (Type == TokenType.OP_SUB)
                        {
                            return "-";
                        }
                        else if (Type == TokenType.OP_MUL)
                        {
                            return "*";
                        }
                        else
                        {
                            return "/";
                        }
                    }
                }
            }


            /// <summary>
            /// Read number from current string position
            /// </summary>
            /// <param name="expression">The string number to be read from</param>
            /// <param name="expressionCounter">The string counter</param>
            /// <returns>The read number</returns>
            private static int ReadNumberFromString(string expression, ref int expressionCounter)
            {
                int result = 0;
                while (expressionCounter < expression.Length && Char.IsDigit(expression[expressionCounter]))
                {
                    result = result * 10 + expression[expressionCounter] - '0';
                    ++expressionCounter;
                }
                return result;
            }

            /// <summary>
            /// Safely read current character and check if it's the given symbol
            /// </summary>
            /// <param name="expression">The string character to be read from</param>
            /// <param name="expressionCounter">The string counter</param>
            /// <param name="checkingCharacter">The symbol character to be compared with</param>
            /// <returns>The read char</returns>
            private static Char ReadAndCheckChar(string expression, int expressionCounter, Char? checkingCharacter)
            {
                if (expressionCounter >= expression.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }
                var ch = expression[expressionCounter];
                if (checkingCharacter != null && ch != checkingCharacter)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return ch;
            }

            /// <summary>
            /// Create new Node element reading input string-expression
            /// </summary>
            /// <param name="parent">The parent of creating Node</param>
            /// <param name="expression">The string Node to be created from</param>
            /// <param name="expressionCounter">The string counter</param>
            /// <returns>The created Node</returns>
            public static Node MakeNode(Node parent, string expression, ref int expressionCounter)
            {
                Node newNode;
                Token newToken;

                var ch = ReadAndCheckChar(expression, expressionCounter, '(');
                ++expressionCounter;

                ch = ReadAndCheckChar(expression, expressionCounter, null);
                ++expressionCounter;
                switch (ch)
                {
                    case '+':
                        newToken = new Token(TokenType.OP_SUM);
                        break;

                    case '-':
                        newToken = new Token(TokenType.OP_SUB);
                        break;

                    case '*':
                        newToken = new Token(TokenType.OP_MUL);
                        break;

                    case '/':
                        newToken = new Token(TokenType.OP_DIV);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                newNode = new Node(newToken, parent);

                ch = ReadAndCheckChar(expression, expressionCounter, ' ');
                ++expressionCounter;



                ch = ReadAndCheckChar(expression, expressionCounter, null);
                if (Char.IsDigit(ch))
                {
                    var newNumberToken = new Token(TokenType.NUM, ReadNumberFromString(expression, ref expressionCounter));
                    newNode.Left = new Node(newNumberToken, parent, null, null);
                }
                else
                {
                    newNode.Left = MakeNode(newNode, expression, ref expressionCounter);
                }

                ch = ReadAndCheckChar(expression, expressionCounter, ' ');
                ++expressionCounter;

                ch = ReadAndCheckChar(expression, expressionCounter, null);
                if (Char.IsDigit(ch))
                {
                    var newNumberToken = new Token(TokenType.NUM, ReadNumberFromString(expression, ref expressionCounter));
                    newNode.Right = new Node(newNumberToken, parent, null, null);
                }
                else
                {
                    newNode.Right = MakeNode(newNode, expression, ref expressionCounter);
                }

                ReadAndCheckChar(expression, expressionCounter, ')');
                ++expressionCounter;

                return newNode;
            }


            /// <summary>
            /// The parent of Node
            /// </summary>
            public Node Parent { get; set; }

            /// <summary>
            /// The left son of Node
            /// </summary>
            public Node Left { get; set; }

            /// <summary>
            /// The right son of Node
            /// </summary>
            public Node Right { get; set; }

            /// <summary>
            /// The value of Node
            /// </summary>
            private Token value;

            /// <summary>
            /// Constuctor for the structure
            /// </summary>
            /// <param name="value">The Node value</param>
            /// <param name="parent">The parent of Node</param>
            /// <param name="left">The left son of Node</param>
            /// <param name="right">The right son of Node</param>
            private Node(Token value, Node parent = null, Node left = null, Node right = null)
            {
                this.value = value;
                Parent = parent;
                Left = left;
                Right = right;
            }


            /// <summary>
            /// Count given operation type with given arguments
            /// </summary>
            /// <param name="value1">The 1st value</param>
            /// <param name="value2">The 2nd value</param>
            /// <param name="type">The type of operation</param>
            /// <returns>The counted result</returns>
            private int MakeOperation(int value1, int value2, TokenType type)
            {
                if (type == TokenType.NUM)
                {
                    throw new InvalidOperationException();
                }

                if (type == TokenType.OP_SUM)
                {
                    return value1 + value2;
                }
                else if (type == TokenType.OP_SUB)
                {
                    return value1 - value2;
                }
                else if (type == TokenType.OP_MUL)
                {
                    return value1 * value2;
                }
                else
                {
                    if (value2 == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    return value1 / value2;
                }
            }

            /// <summary>
            /// Count expression
            /// </summary>
            /// <returns>The counted result</returns>
            public int Count()
            {
                if (value.Type != TokenType.NUM)
                {
                    if (Left == null || Right == null)
                    {
                        throw new DataMisalignedException();
                    }

                    return MakeOperation(Left.Count(), Right.Count(), value.Type); 
                }
                else
                {
                    return value.Number;
                }
            }

            /// <summary>
            /// Print expression
            /// </summary>
            /// <returns>The string form of the expression</returns>
            public string Print()
            {
                string resultString = "";
                if (value.Type == TokenType.NUM)
                {
                    resultString += $"{value.Number}";
                }
                else
                {
                    resultString += $"({value.ToString()} {Left.Print()} {Right.Print()})";
                }
                return resultString;
            }
            
        }

        /// <summary>
        /// The root of the tree
        /// </summary>
        private Node head = null;
        
        /// <summary>
        /// Set new expression
        /// </summary>
        /// <param name="expression">The given expression</param>
        public void SetExpression(string expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException();
            }

            int expressionCounter = 0;
            head = Node.MakeNode(head, expression, ref expressionCounter);
        }

        /// <summary>
        /// Print the expression tree
        /// </summary>
        /// <returns>The string form of the expression tree</returns>
        public string PrintExpression()
        {
            return head.Print();
        }

        /// <summary>
        /// Count the expression tree
        /// </summary>
        /// <returns>The counter result</returns>
        public int Count()
        {
            return head.Count();
        }

    }

}
