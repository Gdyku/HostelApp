using ClientService.Interface;
using ClientService.Logic;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ClientService
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IGuestLogic, GuestLogic>();
            container.RegisterType<IReservationLogic, ReservationLogic>();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}