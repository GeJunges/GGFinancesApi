using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FinancesApi.Logger;
using FinancesApi.Repositories;

namespace FinancesApi.DI {
    public class InstallFindancesApi : IWindsorInstaller {
        public void Install(IWindsorContainer container, IConfigurationStore store) {
            container.Register(
                Component.For<ILoggerWrapper>().ImplementedBy<LoggerWrapper>().LifestyleTransient(),
                Component.For<IExpensesRepository>().ImplementedBy<ExpensesRepository>().LifestyleTransient(),
                Component.For<IDetailsRepository>().ImplementedBy<DetailsRepository>().LifestyleTransient()
            );
        }
    }
}