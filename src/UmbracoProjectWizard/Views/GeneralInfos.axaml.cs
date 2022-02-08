namespace UmbracoProjectWizard.Views;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using UmbracoProjectWizard.ViewModels;

public partial class GeneralInfosView : ReactiveUserControl<GeneralInfosViewModel>
{
    public GeneralInfosView() => InitializeComponent();

    private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
}
