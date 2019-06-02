using System;

namespace Structures
{
    /// <summary>
    /// ADS ParseTree
    /// </summary>
    public class ParseTree
    {
        /// <summary>
        /// The base of Node class
        /// </summary>
        private abstract class Node
        {
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
            /// Constuctor for the structure
            /// </summary>
            /// <param name="parent">The parent of Node</param>
            /// <param name="left">The left son of Node</param>
            /// <param name="right">The right son of Node</param>
            public Node(Node parent = null, Node left = null, Node right = null)
            {
                Parent = parent;
                Left = left;
                Right = right;
            }


            /// <summary>
            /// Count Node result
            /// </summary>
            /// <returns>The counted result</returns>
            public abstract int Count();

            /// <summary>
            /// Print expression
            /// </summary>
            /// <returns>The string form of the expression</returns>
            public abstract string Print();

        }

        /// <summary>
        /// The specific Node type for operations
        /// </summary>
        private abstract class OperationNode : Node
        {
            /// <summary>
            /// Make the Node type operation with 2 arguments
            /// </summary>
            protected abstract int MakeOperation(int value1, int value2);

            /// <summary>
            /// Count the Node result
            /// </summary>
            public override int Count()
            {
                if (Left == null || Right == null)
                {
                    throw new DataMisalignedException();
                }

                return MakeOperation(Left.Count(), Right.Count());
            }

            /// <summary>
            /// Get the Node type sign of operation
            /// </summary>
            protected abstract string GetSignOfOperation();

            /// <summary>
            /// Print the Node operation
            /// </summary>
            public override string Print()
            {
                if (Left == null || Right == null)
                {
                    throw new DataMisalignedException();
                }

                return $"({GetSignOfOperation()} {Left.Print()} {Right.Print()})";
            }

            /// <summary>
            /// Basic Node constructor
            /// </summary>
            public OperationNode(Node parent, Node left, Node right) : base(parent, left, right) { }

        }


        /// <summary>
        /// The Node type for numbers
        /// </summary>
        private class NumberNode : Node
        {
            /// <summary>
            /// The storing value
            /// </summary>
            private int value;

            /// <summary>
            /// Cound the Node type
            /// </summary>
            public override int Count() => value;

            /// <summary>
            /// Print the Node type
            /// </summary>
            public override string Print() => $"{value}";

            /// <summary>
            /// Constructor for the Node type
            /// </summary>
            /// <param name="value">The given value</param>
            public NumberNode(int value, Node parent = null, Node left = null, Node right = null) : base(parent, left, right)
            {
                this.value = value;
            }

        }

        /// <summary>
        /// The Node type for + operation
        /// </summary>
        private class OperationNodePlus : OperationNode
        {
            /// <summary>
            /// The Node type counting operation
            /// </summary>
            protected override int MakeOperation(int value1, int value2) => value1 + value2;

            /// <summary>
            /// The Node type operation sign
            /// </summary>
            protected override string GetSignOfOperation() => "+";

            /// <summary>
            /// Basic OperationNode constructor
            /// </summary>
            public OperationNodePlus(Node parent = null, Node left = null, Node right = null) : base(parent, left, right) { }

        }

        /// <summary>
        /// The Node type for - operation
        /// </summary>
        private class OperationNodeMinus : OperationNode
        {
            /// <summary>
            /// The Node type counting operation
            /// </summary>
            protected override int MakeOperation(int value1, int value2) => value1 - value2;

            /// <summary>
            /// The Node type operation sign
            /// </summary>
            protected override string GetSignOfOperation() => "-";

            /// <summary>
            /// Basic OperationNode constructor
            /// </summary>
            public OperationNodeMinus(Node parent = null, Node left = null, Node right = null) : base(parent, left, right) { }

        }

        /// <summary>
        /// The Node type for * operation
        /// </summary>
        private class OperationNodeMultiply : OperationNode
        {
            /// <summary>
            /// The Node type counting operation
            /// </summary>
            protected override int MakeOperation(int value1, int value2) => value1 * value2;

            /// <summary>
            /// The Node type operation sign
            /// </summary>
            protected override string GetSignOfOperation() => "*";

            /// <summary>
            /// Basic OperationNode constructor
            /// </summary>
            public OperationNodeMultiply(Node parent = null, Node left = null, Node right = null) : base(parent, left, right) { }

        }

        /// <summary>
        /// The Node type for / operation
        /// </summary>
        private class OperationNodeDivide : OperationNode
        {
            /// <summary>
            /// The Node type counting operation
            /// </summary>
            protected override int MakeOperation(int value1, int value2) => value1 / value2;

            /// <summary>
            /// The Node type operation sign
            /// </summary>
            protected override string GetSignOfOperation() => "/";

            /// <summary>
            /// Basic OperationNode constructor
            /// </summary>
            public OperationNodeDivide(Node parent = null, Node left = null, Node right = null) : base(parent, left, right) { }

        }

        /// <summary>
        /// Constructing ParseTree functions consister
        /// </summary>
        private static class ConstructTreeFuncton
        {
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
            /// Make new Node by parsing input expression
            /// </summary>
            /// <param name="parent">The parent of new Node</param>
            /// <param name="expression">The parsing expression</param>
            /// <param name="expressionCounter">The expression counter</param>
            public static Node MakeNode(Node parent, string expression, ref int expressionCounter)
            {
                Node newNode;
                var ch = ReadAndCheckChar(expression, expressionCounter, '(');
                ++expressionCounter;

                ch = ReadAndCheckChar(expression, expressionCounter, null);
                ++expressionCounter;
                switch (ch)
                {
                    case '+':
                        newNode = new OperationNodePlus(parent);
                        break;

                    case '-':
                        newNode = new OperationNodeMinus(parent);
                        break;

                    case '*':
                        newNode = new OperationNodeMultiply(parent);
                        break;

                    case '/':
                        newNode = new OperationNodeDivide(parent);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                ch = ReadAndCheckChar(expression, expressionCounter, ' ');
                ++expressionCounter;



                ch = ReadAndCheckChar(expression, expressionCounter, null);
                if (Char.IsDigit(ch))
                {
                    newNode.Left = new NumberNode(ReadNumberFromString(expression, ref expressionCounter), parent);
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
                    newNode.Right = new NumberNode(ReadNumberFromString(expression, ref expressionCounter), parent);
                }
                else
                {
                    newNode.Right = MakeNode(newNode, expression, ref expressionCounter);
                }

                ReadAndCheckChar(expression, expressionCounter, ')');
                ++expressionCounter;

                return newNode;
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
            head = ConstructTreeFuncton.MakeNode(head, expression, ref expressionCounter);
        }

        /// <summary>
        /// Print the expression tree
        /// </summary>
        /// <returns>The string form of the expression tree</returns>
        public string PrintExpression()
        {
            if (head == null)
            {
                throw new ArgumentNullException();
            }

            return head.Print();
        }

        /// <summary>
        /// Count the expression tree
        /// </summary>
        /// <returns>The counter result</returns>
        public int Count()
        {
            if (head == null)
            {
                throw new ArgumentNullException();
            }

            return head.Count();
        }

    }

}
