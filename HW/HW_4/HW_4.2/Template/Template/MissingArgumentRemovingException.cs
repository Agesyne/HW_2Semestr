using System;

namespace CustomExceptions
{
    /// <summary>
    /// Custom exception: missing removing argument
    /// </summary>
    [Serializable]
    public class MissingArgumentRemovingException : Exception
    {
        public MissingArgumentRemovingException() { }
        public MissingArgumentRemovingException(string message) : base(message) { }
        public MissingArgumentRemovingException(string message, Exception inner)
            : base(message, inner) { }
        protected MissingArgumentRemovingException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
                : base(info, context) { }
    }

}