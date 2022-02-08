namespace UmbracoProjectWizard.Views;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using UmbracoProjectWizard.ViewModels;

public partial class ProjectCreation : ReactiveUserControl<ProjectCreationViewModel>
{
    public ProjectCreation() => InitializeComponent();

    private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
}
