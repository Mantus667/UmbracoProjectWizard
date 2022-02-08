namespace UmbracoProjectWizard.Views;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using UmbracoProjectWizard.ViewModels;

public partial class HomeView : ReactiveUserControl<HomeViewModel>
{
    public HomeView() => InitializeComponent();

    private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
}
