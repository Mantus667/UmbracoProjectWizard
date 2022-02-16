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
#pragma warning disable CS8604 // Mögliches Nullverweisargument.
    public PackagesViewModel(IScreen screen) : this(screen, Locator.Current.GetService<IPackagesProvider>())
#pragma warning restore CS8604 // Mögliches Nullverweisargument.
    {
    }

    public PackagesViewModel(IScreen screen, IPackagesProvider packagesProvider)
    {
        ArgumentNullException.ThrowIfNull(screen, nameof(screen));
        ArgumentNullException.ThrowIfNull(packagesProvider, nameof(packagesProvider));

        HostScreen = screen;
        AvailablePackages = packagesProvider.GetPackages();
        Save = ReactiveCommand.Create(SaveImplementation);
    }

    public string? UrlPathSegment => nameof(PackagesViewModel);

    public IScreen HostScreen { get; }

    public ObservableCollection<UmbracoPackage> SelectedPackages { get; } = new ObservableCollection<UmbracoPackage>();

    public List<UmbracoPackageCategory> AvailablePackages { get; }

    public ReactiveCommand<Unit, Unit> Save { get; set; }
    public void SaveImplementation() => HostScreen.Router.Navigate.Execute(new ProjectCreationViewModel(HostScreen));
}
