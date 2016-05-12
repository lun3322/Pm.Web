using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MEFDemo {
    [Export]
    public class CreationPolicyTest {
        public void Run() {
            var container = Program.Container;
            var p1 = container.GetExport<Policy1>();
            var p2 = container.GetExport<Policy2>();
            p1?.Value.Test();
            p2?.Value.Test();
            p2?.Value.Test();
        }
    }

    [Export]
    public class Policy1 {
        [Import(typeof(IPolicySub), RequiredCreationPolicy = CreationPolicy.Shared)]
        private IPolicySub PolicySub { get; set; }

        public void Test() {
            var num = PolicySub.GetNumber();
            Console.WriteLine(num);
        }
    }

    [Export]
    public class Policy2 {
        [Import(typeof(IPolicySub), RequiredCreationPolicy = CreationPolicy.Shared)]
        private IPolicySub PolicySub { get; set; }

        public void Test() {
            var num = PolicySub.GetNumber();
            Console.WriteLine(num);
        }
    }

    public interface IPolicySub {
        int GetNumber();
    }

    [Export(typeof(IPolicySub))]
    public class PolicySub : IPolicySub {
        public int Number = 0;
        public int GetNumber() {
            Number++;
            return Number;
        }
    }
}
