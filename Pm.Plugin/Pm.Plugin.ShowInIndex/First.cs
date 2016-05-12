using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using Pm.Plugin.Core;

namespace Pm.Plugin.ShowInIndex {
    [Export(typeof(IIndexBlock))]
    public class First : IIndexBlock {
        public string GetText() {
            return "全球最大的中文搜索引擎、致力于让网民更便捷地获取信息，找到所求。百度超过千亿的中文网页数据库，可以瞬间找到相关的搜索结果。";
        }

        public string GetTitle() {
            return "百度";
        }

        public string GetLink() {
            return "http://www.baidu.com";
        }
    }
}
