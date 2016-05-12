using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pm.Web.Models.Home {
    public class IndexViewModel {
        public IEnumerable<IndexBlock> Blocks { get; set; }
    }

    public class IndexBlock {
        public string Text { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
    }
}