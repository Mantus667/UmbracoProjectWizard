namespace UmbracoProjectWizard.DependencyInjection;
using ReactiveUI;
using Splat;
using UmbracoProjectWizard.ViewModels;
using UmbracoProjectWizard.Views;

public class Bootstrapper
{
    public static void Register(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        PackagesBootstrapper.Register(services);
        services.Register(() => new HomeView(), typeof(IViewFor<HomeViewModel>));
        services.Register(() => new GeneralInfosView(), typeof(IViewFor<GeneralInfosViewModel>));
        services.Register(() => new UnattendedInstall(), typeof(IViewFor<UnattendedInstallViewModel>));
        services.Register(() => new Packages(), typeof(IViewFor<PackagesViewModel>));
        services.Register(() => new ProjectCreation(), typeof(IViewFor<ProjectCreationViewModel>));
        //services.RegisterLazySingleton(() => new WizardContext());
        //services.RegisterLazySingleton<MainWindowViewModel>(() => new MainWindowViewModel());
    }
}
