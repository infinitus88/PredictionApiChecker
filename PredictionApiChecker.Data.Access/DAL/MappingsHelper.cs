using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PredictionApiChecker.Data.Access.Maps.Common;
using PredictionApiChecker.Data.Access.Maps.Main;
using PredictionApiChecker.Data.Access.Maps.Main.Football;

namespace PredictionApiChecker.Data.Access.DAL
{
    public static class MappingsHelper
    {
        public static IEnumerable<IMap> GetMainMappings()
        {
            var assemblyTypes = typeof(ExampleMap).GetTypeInfo().Assembly.DefinedTypes;
            var mappings = assemblyTypes
                .Where(t => t.Namespace != null && t.Namespace.Contains(typeof(ExampleMap).Namespace))
                .Where(t => typeof(IMap).GetTypeInfo().IsAssignableFrom(t));
            mappings = mappings.Where(x => !x.IsAbstract);

            return mappings.Select(m => (IMap)Activator.CreateInstance(m.AsType())).ToArray();
        }
    }
}