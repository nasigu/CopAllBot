using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supreme.Core.KeywordSearchEngine
{
    public interface IKeyWordEngine
    {
        bool Search(IKeyWordEngine engine, string text);
    }
}
