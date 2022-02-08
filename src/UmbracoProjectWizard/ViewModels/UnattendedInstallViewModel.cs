namespace UmbracoProjectWizard.ViewModels;
using ReactiveUI;

public class UnattendedInstallViewModel : ReactiveObject, IRoutableViewModel
{
    public UnattendedInstallViewModel(IScreen screen) => HostScreen = screen;

    public string? UrlPathSegment => nameof(UnattendedInstallViewModel);

    public IScreen HostScreen { get; }
}
