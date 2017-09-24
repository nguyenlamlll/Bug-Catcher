using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugCatcher.Exception
{
    /// <summary>
    /// The exception that is thrown when the returning result is null when it is expected to have something.
    /// </summary>
    public class NullResultException : System.Exception
    {
        public IEnumerable<string> ErrorMessages { get; set; }
        
        public NullResultException(string message, System.Exception innerException = null)
            : base(message, innerException)
        {
            this.ErrorMessages = new[] { message };
            
        }

        public NullResultException(IEnumerable<string> messages, System.Exception innerException = null)
            : base(string.Join("\r\n", messages), innerException)
        {
            ErrorMessages = messages;
        }
    }
}
