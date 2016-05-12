using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pm.Plugin.Core;

namespace Pm.Plugin.ShowInIndex {
    [Export(typeof(IIndexBlock))]
    public class Google : IIndexBlock {
        public string GetText() {
            return "Google（中文名：谷歌），是一家美国的跨国科技企业，致力于互联网搜索、云计算、广告技术等领域，开发并提供大量基于互联网的产品与服务，其主要利润来自于AdWords等广告服务。Google由当时在斯坦福大学攻读理工博士的拉里·佩奇和谢尔盖·布卢姆共同创建，因此两人也被称为“Google Guys”。";
        }

        public string GetTitle() {
            return "谷歌";
        }

        public string GetLink() {
            return "http://www.google.com";
        }
    }
}
