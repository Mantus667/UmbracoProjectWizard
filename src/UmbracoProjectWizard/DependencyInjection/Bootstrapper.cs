namespace UmbracoProjectWizard.DependencyInjection;
using ReactiveUI;
using Splat;
using UmbracoProjectWizard.ViewModels;
using UmbracoProjectWizard.Views;

public class Bootstrapper
{
    public static void Register(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        services.Register(() => new HomeView(), typeof(IViewFor<HomeViewModel>));
        services.Register(() => new GeneralInfosView(), typeof(IViewFor<GeneralInfosViewModel>));
        //services.RegisterLazySingleton(() => new WizardContext());
        //services.RegisterLazySingleton<MainWindowViewModel>(() => new MainWindowViewModel());
    }
}
