using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using UserFormSubmission.Services;
using UserFormSubmission.Controllers;
using UserFormSubmission.Repo;

namespace UserFormSubmission
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
            var container = new UnityContainer();

            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserRepository, UserRepository>();

            container.RegisterType<IController, UserController>("Store");

            return container;
        }

    public static void RegisterTypes(IUnityContainer container)
    {
    
    }
  }
}