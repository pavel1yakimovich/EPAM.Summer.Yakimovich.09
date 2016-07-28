using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Task04Logic
{
    /// <summary>
    /// creator. create - fabric method
    /// </summary>
    public abstract class BookListStorageCreator
    {
        public abstract IBookListStorage Create(string fileName, ILogger logger = null, IFormatter formatter = null);
    }
}
