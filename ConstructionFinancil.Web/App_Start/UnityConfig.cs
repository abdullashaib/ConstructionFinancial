using ConstructionFinancial.DataEntity;
using ConstructionFinancial.DataEntity.TaskModel;
using ConstructionFinancial.Domain.Account;
using ConstructionFinancial.Domain.GeneralLedger;
using ConstructionFinancial.Domain.TaskModel;
using ConstructionFinancial.Service;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ConstructionFinancil.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAccountGroupService, AccountGroupService>();
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<IAccountGroupRepository, AccountGroupRepository>();
            container.RegisterType<ITrialBalanceRepository, TrialBalanceRepository>();
            container.RegisterType<ITaskStatusRepository, TaskStatusRepository>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}