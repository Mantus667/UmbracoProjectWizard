namespace UmbracoProjectWizard.ViewModels;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using Splat;
using UmbracoProjectWizard.Models;
using UmbracoProjectWizard.Services;

public class PackagesViewModel : ReactiveObject, IRoutableViewModel
{
    private readonly IWizardContextProvider _wizardContextProvider;
#pragma warning disable CS8604 // Mögliches Nullverweisargument.
    public PackagesViewModel(IScreen screen)
        : this(screen, Locator.Current.GetService<IPackagesProvider>(), Locator.Current.GetService<IWizardContextProvider>())
#pragma warning restore CS8604 // Mögliches Nullverweisargument.
    {
    }

    public PackagesViewModel(IScreen screen, IPackagesProvider packagesProvider, IWizardContextProvider wizardContextProvider)
    {
        ArgumentNullException.ThrowIfNull(screen, nameof(screen));
        ArgumentNullException.ThrowIfNull(packagesProvider, nameof(packagesProvider));
        ArgumentNullException.ThrowIfNull(wizardContextProvider, nameof(wizardContextProvider));

        HostScreen = screen;
        _wizardContextProvider = wizardContextProvider;
        AvailablePackages = packagesProvider.GetPackages();
        Save = ReactiveCommand.Create(SaveImplementation);
    }

    public string? UrlPathSegment => nameof(PackagesViewModel);

    public IScreen HostScreen { get; }

    public ObservableCollection<UmbracoPackage> SelectedPackages { get; } = new ObservableCollection<UmbracoPackage>();

    public List<UmbracoPackageCategory> AvailablePackages { get; }

    public ReactiveCommand<Unit, Unit> Save { get; set; }
    public void SaveImplementation()
    {
        var context = _wizardContextProvider.GetWizardContext();
        context.SetSelectedPackages(SelectedPackages);
        HostScreen.Router.Navigate.Execute(new ProjectCreationViewModel(HostScreen));
    }
}
