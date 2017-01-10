using System;
using Microsoft.Practices.Unity;
using MvcRedisDemo.Sevices;

namespace MvcRedisDemo
{
    /// <summary>
    /// Specifies the Unity configuration for the main unityContainer.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity unityContainer.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity unityContainer.</summary>
        /// <param name="unityContainer">The unity unityContainer to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer unityContainer)
        {
            unityContainer.RegisterType<IDatabaseContext, DatabaseContext>();
            unityContainer.RegisterType<IHeroService, HeroService>();
        }
    }
}
