using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FinancesApi.Logger;
using FinancesApi.Repositories;

namespace FinancesApi.DI {
    public class InstallFindancesApi : IWindsorInstaller {
        public void Install(IWindsorContainer container, IConfigurationStore store) {
            container.Register(
                Component.For(typeof(IPersistenceRepository<>)).ImplementedBy(typeof(PersistenceRepository<>)).LifestyleTransient(),
                Component.For(typeof(ISearchRepository<>)).ImplementedBy(typeof(SearchRepository<>)).LifestyleTransient(),
                Component.For<ILoggerWrapper>().ImplementedBy<LoggerWrapper>().LifestyleTransient()
            );
        }
    }
}