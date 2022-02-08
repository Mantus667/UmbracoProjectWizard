namespace UmbracoProjectWizard.ViewModels;

using System;
using ReactiveUI;

public class GeneralInfosViewModel : ReactiveObject, IRoutableViewModel
{
    //private readonly WizardContext _wizardContext;

    public GeneralInfosViewModel(IScreen screen) => HostScreen = screen;

    public string? UrlPathSegment { get; } = Guid.NewGuid().ToString()[..5];

    public IScreen HostScreen { get; }
}