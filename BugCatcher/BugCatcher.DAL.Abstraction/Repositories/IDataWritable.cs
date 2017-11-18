using System;
using System.Collections.Generic;
using System.Text;

namespace BugCatcher.DAL.Abstraction.Repositories
{
    public interface IDataWritable
    {
        void Save();
    }
}
