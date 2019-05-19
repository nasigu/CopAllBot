using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supreme.Core.KeywordSearchEngine
{
    interface IKeyWordEngine
    {
        bool Search(string text, List<string> keywords);
    }
}
