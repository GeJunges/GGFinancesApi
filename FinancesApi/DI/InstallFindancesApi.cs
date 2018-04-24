using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FinancesApi.Logger;

namespace FinancesApi.DI {
    public class InstallFindancesApi : IWindsorInstaller {
        public void Install(IWindsorContainer container, IConfigurationStore store) {
            container.Register(
                Component.For<ILoggerWrapper>().ImplementedBy<LoggerWrapper>().LifestyleTransient()
            );
        }
    }
}