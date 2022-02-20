namespace UmbracoProjectWizard.Views;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using UmbracoProjectWizard.ViewModels;

public partial class ProjectCreation : ReactiveUserControl<ProjectCreationViewModel>
{
    public ProjectCreation()
    {
        InitializeComponent();

        this.WhenActivated(d => ViewModel!.CreateTasks());
    }

    private void InitializeComponent() => AvaloniaXamlLoader.Load(this);
}
