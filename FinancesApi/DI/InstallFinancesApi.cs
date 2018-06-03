using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FinancesApi.Logger;
using FinancesApi.Repositories;

namespace FinancesApi.DI {
    public class InstallFinancesApi : IWindsorInstaller {
        public void Install(IWindsorContainer container, IConfigurationStore store) {
            container.Register(
                Component.For<ILoggerWrapper>().ImplementedBy<LoggerWrapper>().LifestyleTransient(),
                Component.For<IIncomesDateRepository>().ImplementedBy<IncomesDateRepository>().LifestyleTransient(),
                Component.For<IExpensesDateRepository>().ImplementedBy<ExpensesDateRepository>().LifestyleTransient(),
                Component.For<IExpensesDetailsRepository>().ImplementedBy<ExpensesDetailsRepository>().LifestyleTransient(),
                Component.For<IDetailsRepository>().ImplementedBy<DetailsRepository>().LifestyleTransient(),
                Component.For<IRegisterRepository>().ImplementedBy<RegisterRepository>().LifestyleTransient()
            );
        }
    }
}