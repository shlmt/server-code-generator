using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerGenerator
{
    internal interface IGenerate<T>
    {
        public T Generate();
    }
}
