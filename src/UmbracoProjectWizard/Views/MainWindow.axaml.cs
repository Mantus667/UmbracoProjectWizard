namespace UmbracoProjectWizard.Views;
using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using UmbracoProjectWizard.ViewModels;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        GlobalCommand.UseMaterialUIDarkTheme();
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
}
