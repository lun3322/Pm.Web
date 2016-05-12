using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pm.Plugin.Core {
    public interface IIndexBlock {
        string GetText();
        string GetTitle();
        string GetLink();
    }
}
