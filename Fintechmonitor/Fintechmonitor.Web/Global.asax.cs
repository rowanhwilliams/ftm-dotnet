﻿using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using Fintechmonitor.Services;
using Fintechmonitor.Repository;
using System.Data;
using System.Configuration;
using Fintechmonitor.Repository.Mapping;

namespace Fintechmonitor.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var dapperBootstrapper = new DapperBootstrapper();
            dapperBootstrapper.Run();

            BootstrapAutofac();
        }

        private void BootstrapAutofac()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers.
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            SetupRegistrations(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private void SetupRegistrations(ContainerBuilder builder)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ftmdb"].ConnectionString;
            builder.Register(c => new MySql.Data.MySqlClient.MySqlConnection(connectionString)).As<IDbConnection>().InstancePerRequest();

            builder.RegisterType<CompanyService>().AsImplementedInterfaces();
            builder.RegisterType<CompanyRepository>().AsImplementedInterfaces();

            builder.RegisterType<NewsService>().AsImplementedInterfaces();
            builder.RegisterType<NewsRepository>().AsImplementedInterfaces();
        }
    }
}
