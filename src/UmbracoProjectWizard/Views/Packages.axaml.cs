namespace UmbracoProjectWizard.Views;

using System.Linq;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using UmbracoProjectWizard.Models;
using UmbracoProjectWizard.ViewModels;

public partial class Packages : ReactiveUserControl<PackagesViewModel>
{
    public Packages()
    {
        InitializeComponent();

        var treeView = this.FindControl<TreeView>("PackageSelectionTree");
        treeView.SelectionChanged += TreeView_SelectionChanged;
    }

    private void TreeView_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (ViewModel is null)
        {
            return;
        }
        foreach (var removedItem in e.RemovedItems.OfType<UmbracoPackage>())
        {
            ViewModel.SelectedPackages.Remove(removedItem);
        }
        foreach (var addedItem in e.AddedItems.OfType<UmbracoPackage>())
        {
            ViewModel.SelectedPackages.Add(addedItem);
        }
    }

    private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
}
