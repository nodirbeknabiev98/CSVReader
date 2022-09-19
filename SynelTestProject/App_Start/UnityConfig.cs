
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

using SynelTestProject.DAL.Repositories;
using SynelTestProject.DAL.Interfaces;
using System.Web.Http; // => for GlobalConfiguration

using SynelTestProject.DAL.Utilities.CustomMapper;

namespace SynelTestProject
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IEmployee, EmployeeRepo>();
            container.RegisterType<IEmployeeAPI, EmployeeAPIRepo>();

            container.RegisterType<ISimpleMapper, SimpleMapperRepo>();


            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));  // Unity.Mvc5 
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container); //Unit.WebAPI
        }
    }
}