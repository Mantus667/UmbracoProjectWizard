namespace UmbracoProjectWizard.Views;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using UmbracoProjectWizard.ViewModels;

public partial class UnattendedInstall : ReactiveUserControl<UnattendedInstallViewModel>
{
    public UnattendedInstall() => InitializeComponent();

    private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
}
