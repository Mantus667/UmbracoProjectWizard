namespace UmbracoProjectWizard.Views;

using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using UmbracoProjectWizard.ViewModels;

public partial class GeneralInfosView : ReactiveUserControl<GeneralInfosViewModel>
{
    public GeneralInfosView()
    {
        InitializeComponent();

        this.WhenActivated(d => d(ViewModel!.ShowOpenFolderDialog.RegisterHandler(ShowOpenFolderDialog)));
    }

    private void InitializeComponent() => AvaloniaXamlLoader.Load(this);

    private async Task ShowOpenFolderDialog(InteractionContext<Window, string?> interaction)
    {
        var dialog = new OpenFolderDialog
        {
            Title = "Select output folder"
        };
        var folderName = await dialog.ShowAsync(interaction.Input);
        interaction.SetOutput(folderName);
    }
}
