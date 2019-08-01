using BoardGameGroup.DAL;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace BoardGameGroup
{
    public static class UnityConfig
    {
        public static IUnityContainer GetContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IRepository, Repository>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }
    }
}