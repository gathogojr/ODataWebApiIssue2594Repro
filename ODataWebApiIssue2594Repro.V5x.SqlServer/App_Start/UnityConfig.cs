using System;
using ODataWebApiIssue2594Repro.V5x.Data;
using Unity;

namespace ODataWebApiIssue2594Repro.V5x.App_Start
{
    public class UnityConfig
    {
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterInstance(new V5XDbContext("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\V5xDb.mdf;Integrated Security=True;MultipleActiveResultSets=True;App=EntityFramework"));
        }
    }
}