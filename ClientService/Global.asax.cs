using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using ClientService.Mapper;

namespace ClientService
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            var mapper = config.CreateMapper();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
