using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Template
{
    /// <summary>
    /// Special exception to throw if struct is empty
    /// </summary>
    [Serializable]
    public class StructIsEmptyException : Exception
    {
        public StructIsEmptyException() { }
        public StructIsEmptyException(string message, Exception inner) 
            : base(message, inner)
        {
            Console.WriteLine("Struct is empty => extracting is impossible.");
        }
        protected StructIsEmptyException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
                : base(info, context) { }
    }
}
