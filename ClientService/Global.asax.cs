using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using ClientService.Mapper;
using System.Web.Http;
using ClientService.Models;
using ClientService.DtoModels;
using System.Web.Optimization;

namespace ClientService
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<MappingProfile>());           
        }
    }
}
