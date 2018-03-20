
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace FinancesApi.AutoMapper {
    public class AutoMapperConfiguration {
        public static void RegisterMappings() {
            var type = typeof(ICustomMappingInitializer);
            var initializers = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            foreach (var t in initializers) {
                if (t.GetTypeInfo().IsInterface) continue;
                var instance = (ICustomMappingInitializer)Activator.CreateInstance(t);
                LoadCustomMappings(instance.GetTypesFromAssembly());
            }
        }

        private static void LoadCustomMappings(IEnumerable<Type> types) {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t)
                              && !t.GetTypeInfo().IsAbstract
                              && !t.GetTypeInfo().IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

            Mapper.Initialize(cfg => {
                cfg.CreateMissingTypeMaps = true;
                foreach (var map in maps) {
                    map.CreateMappings(cfg);
                }
            });
        }
    }

}
