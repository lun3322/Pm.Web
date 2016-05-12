using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MEFDemo {
    class Program {
        // public static AggregateCatalog Catalog;
        public static CompositionContainer Container;

        static void Main(string[] args) {
            var manager = new Manager();
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly()));
            Container = new CompositionContainer(catalog);
            Container.ComposeParts(manager);

            manager.ShowOne();
            manager.ShowMany();
            var managerCtor = Container.GetExport<ManagerCtor>();
            if (managerCtor != null) {
                managerCtor.Value.ShowConstructor();
            }

            var export = Container.GetExport<Manager>();
            export?.Value.ShowOne();

            Console.WriteLine("-----------------------");

            var policy = Container.GetExport<CreationPolicyTest>();
            policy?.Value.Run();
        }
    }

    [Export]
    public class ManagerCtor {
        private readonly IConstructorSub _constructorSub;

        public ManagerCtor() { }

        [ImportingConstructor]
        public ManagerCtor(IConstructorSub constructorSub) {
            _constructorSub = constructorSub;
        }

        public void ShowConstructor() {
            Console.WriteLine("constructorSub.GetName() {0}", _constructorSub.GetName());
        }
    }

    [Export]
    public class Manager {
        [Import(typeof(ISub))]
        private ISub Isub { get; set; }

        [ImportMany(typeof(IManySub))]
        private IEnumerable<Lazy<IManySub>> ImanySub { get; set; }

        public void ShowOne() {
            Console.WriteLine("Isub.GetName() {0}", Isub.GetName());
        }

        public void ShowMany() {
            foreach (var item in ImanySub) {
                Console.WriteLine("item.GetName() {0}", item.Value.GetName());
            }
        }
    }

    public interface ISub {
        string GetName();
    }

    [Export(typeof(ISub))]
    public class SubOne : ISub {
        public string ModelName = "SubOne";

        public string GetName() {
            return ModelName;
        }
    }

    public interface IManySub {
        string GetName();
    }

    [Export(typeof(IManySub))]
    public class ManySubOne : IManySub {
        public string ModelName = "ManySubOne";

        public string GetName() {
            return ModelName;
        }
    }

    [Export(typeof(IManySub))]
    public class ManySubTwo : IManySub {
        public string ModelName = "ManySubTwo";

        public string GetName() {
            return ModelName;
        }
    }

    [Export(typeof(IManySub))]
    public class ManySubThree : IManySub {
        public string ModelName = "ManySubThree";

        public string GetName() {
            return ModelName;
        }
    }

    public interface IConstructorSub {
        string GetName();
    }

    [Export(typeof(IConstructorSub))]
    public class ConstructorSub : IConstructorSub {
        public string ModelName = "ConstructorSub";

        public string GetName() {
            return ModelName;
        }
    }
}
