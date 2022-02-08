namespace UmbracoProjectWizard.ViewModels;
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

    //public void ShowHomeView() => Content = new HomeViewModel();

    public void StartWizard() => Router.Navigate.Execute(new GeneralInfosViewModel(this));
}
