using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pm.Web {
    public class MefDependencySolver : IDependencyResolver {
        private readonly ComposablePartCatalog _catalog;
        private const string HttpContextKey = "MefContainerKey";

        public MefDependencySolver(ComposablePartCatalog catalog) {
            _catalog = catalog;
        }

        public CompositionContainer Container {
            get {
                var container = new CompositionContainer(_catalog);
                HttpContext.Current.Application["Container"] = container;
                return container;
            }
        }

        public object GetService(Type serviceType) {
            var contractName = AttributedModelServices.GetContractName(serviceType);
            return Container.GetExportedValueOrDefault<object>(contractName);
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return Container.GetExportedValues<object>(serviceType.FullName);
        }
    }
}