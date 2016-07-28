using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Task04Logic
{
    /// <summary>
    /// create - fabric method
    /// </summary>
    public sealed class XMLBookListStorageCreator : BookListStorageCreator
    {
        public override IBookListStorage Create(string fileName, ILogger logger = null, IFormatter formatter = null)
        {
            return new XMLBookListStorage(fileName, logger);
        }
    }
}
