namespace UmbracoProjectWizard.ViewModels;
using System.Collections.ObjectModel;
using ReactiveUI;

public class PackagesViewModel : ReactiveObject, IRoutableViewModel
{
    public PackagesViewModel(IScreen screen)
    {
        Items = CreateItems();
        HostScreen = screen;
    }

    private static ObservableCollection<string> CreateItems() => new()
    {
        "Clean",
        "uSync"
    };

    public string? UrlPathSegment => nameof(PackagesViewModel);

    public IScreen HostScreen { get; }

    public ObservableCollection<string> Items { get; }

    public ObservableCollection<string> SelectedItems { get; } = new ObservableCollection<string>();
}
