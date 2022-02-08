namespace UmbracoProjectWizard.ViewModels;
using ReactiveUI;

public class HomeViewModel : ReactiveObject, IRoutableViewModel
{
    public HomeViewModel(IScreen screen) => HostScreen = screen;

    public string? UrlPathSegment { get; } = nameof(HomeViewModel);

    public IScreen HostScreen { get; }
}
