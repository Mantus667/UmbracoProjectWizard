namespace UmbracoProjectWizard.Views;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using UmbracoProjectWizard.ViewModels;

public partial class Packages : ReactiveUserControl<PackagesViewModel>
{
    public Packages() => InitializeComponent();

    private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
}
