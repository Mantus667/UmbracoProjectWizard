namespace UmbracoProjectWizard.ViewModels;

using ReactiveUI;

public class ProjectCreationViewModel : ReactiveObject, IRoutableViewModel
{
    public ProjectCreationViewModel(IScreen screen) => HostScreen = screen;

    public string? UrlPathSegment => nameof(ProjectCreationViewModel);

    public IScreen HostScreen { get; }
}
