namespace UmbracoProjectWizard.ViewModels;

using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;

public class MainWindowViewModel : ReactiveObject, IScreen
{
    //private readonly WizardContext _wizardContext;

    public MainWindowViewModel()//WizardContext wizardContext)
    {
        //_wizardContext = wizardContext;
        Router.Navigate.Execute(new HomeViewModel(this));
    }

    public RoutingState Router { get; } = new RoutingState();

    public void ShowHomeView() => Router.Navigate.Execute(new HomeViewModel(this));

    public void StartWizard() => Router.Navigate.Execute(new GeneralInfosViewModel(this));

    public void ShowUnattendedInstall() => Router.Navigate.Execute(new UnattendedInstallViewModel(this));

    public void ShowPackages() => Router.Navigate.Execute(new PackagesViewModel(this));

    public void ShowProjectCreation() => Router.Navigate.Execute(new ProjectCreationViewModel(this));

    public void GoBack() => Router.NavigateBack.Execute();
}
