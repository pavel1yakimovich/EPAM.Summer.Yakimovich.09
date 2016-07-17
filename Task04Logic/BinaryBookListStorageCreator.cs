using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04Logic
{
    /// <summary>
    /// create - fabric method
    /// </summary>
    public sealed class BinaryBookListStorageCreator : BookListStorageCreator
    {
        public override IBookListStorage Create(string fileName)
        {
            return new BinaryBookListStorage(fileName);
        }
    }
}
