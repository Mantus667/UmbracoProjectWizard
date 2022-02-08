namespace UmbracoProjectWizard.ViewModels;
using ReactiveUI;

public class GeneralInfosViewModel : ReactiveObject, IRoutableViewModel
{
    //private readonly WizardContext _wizardContext;

    public GeneralInfosViewModel(IScreen screen) => HostScreen = screen;

    public string? UrlPathSegment { get; } = nameof(GeneralInfosViewModel);

    public IScreen HostScreen { get; }
}
