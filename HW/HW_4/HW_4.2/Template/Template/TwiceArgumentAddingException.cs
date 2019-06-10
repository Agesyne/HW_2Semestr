using System;

namespace CustomExceptions
{
    /// <summary>
    /// Custom exception: adding same argument twice
    /// </summary>
    [Serializable]
    public class TwiceArgumentAddingException : Exception
    {
        public TwiceArgumentAddingException() { }
        public TwiceArgumentAddingException(string message) : base(message) { }
        public TwiceArgumentAddingException(string message, Exception inner)
            : base(message, inner) { }
        protected TwiceArgumentAddingException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
                : base(info, context) { }
    }

}
