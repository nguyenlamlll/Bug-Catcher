using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.Exception
{
    /// <summary>
    /// The expception is thrown when there is already a record in the database that can be identified
    /// as same as the one is being created or modified.
    /// </summary>
    public class ExistingRecordsException : System.Exception
    {
        public IEnumerable<string> ErrorMessages { get; set; }

        public ExistingRecordsException(string message, System.Exception innerException = null)
            : base(message, innerException)
        {
            this.ErrorMessages = new[] { message };
        }

        public ExistingRecordsException(IEnumerable<string> messages, System.Exception innerException = null)
            : base(string.Join("\r\n", messages), innerException)
        {
            ErrorMessages = messages;
        }
    }
}
