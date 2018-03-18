using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace FinancesApi.DI {
    public class InstallFindancesApi : IWindsorInstaller {
        public void Install(IWindsorContainer container, IConfigurationStore store) {
            container.Register(Classes.FromAssemblyInThisApplication(Assembly.GetExecutingAssembly())
                    .Pick()
                    .WithServiceDefaultInterfaces()
                    .LifestyleTransient());
        }
    }
}