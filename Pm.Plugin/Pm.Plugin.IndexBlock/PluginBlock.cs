using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pm.Plugin.Core;

namespace Pm.Plugin.IndexBlock {
    [Export(typeof(IIndexBlock))]
    public class PluginBlock : IIndexBlock {
        public string GetText() {
            return "这里是插件的描述.下面链接指向qq的下载地址.";
        }

        public string GetTitle() {
            return "一个插件";
        }

        public string GetLink() {
            return "http://im.qq.com";
        }
    }
}
