using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Template
{
    /// <summary>
    /// The class stores pair: value and priority of the
    /// value to be used as an element of some struct
    /// </summary>
    class QueueElement
    {
        public QueueElement next { get; set; }
        public string value { get; }
        public int priority { get; }

        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="val">Storing value</param>
        /// <param name="prior">Priority of the value</param>
        public QueueElement(string val, int priority)
        {
            this.value = val;
            this.priority = priority;
        }
    }
}
