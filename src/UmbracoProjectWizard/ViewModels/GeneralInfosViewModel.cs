namespace UmbracoProjectWizard.ViewModels;

using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using ReactiveUI;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Helpers;

public class GeneralInfosViewModel : ReactiveValidationObject, IRoutableViewModel
{
    //private readonly WizardContext _wizardContext;
    public static List<string> UmbracoVersions => new() { "9.0.0", "9.1.0", "9.2.0", "9.3.0" };

    public GeneralInfosViewModel(IScreen screen)
    {
        HostScreen = screen;
        Save = ReactiveCommand.Create(SaveImplementation, this.IsValid());
        _projectName = string.Empty;
        _outputPath = string.Empty;
        _umbracoVersion = "9.3.0";
        _customEmptyScreen = string.Empty;
        OpenFolder = ReactiveCommand.CreateFromTask<Window, Unit>((window) => OpenFolderAsync(window));

        this.ValidationRule(
            viewModel => viewModel.Projectname,
            this.WhenAnyValue(vm => vm.Projectname, name => !string.IsNullOrWhiteSpace(name)),
            "You must specify a valid project name");

        this.ValidationRule(
            viewModel => viewModel.OutputPath,
            this.WhenAnyValue(vm => vm.OutputPath, path => !string.IsNullOrWhiteSpace(path)),
            "You must specify an output path");

        this.ValidationRule(
            viewModel => viewModel.UmbracoVersion,
            this.WhenAnyValue(x => x.UmbracoVersion, version => !string.IsNullOrWhiteSpace(version)),
            "You must specify a version");
    }

    public string? UrlPathSegment { get; } = nameof(GeneralInfosViewModel);

    public IScreen HostScreen { get; }

    public ReactiveCommand<Unit, Unit> Save { get; set; }
    public void SaveImplementation() => HostScreen.Router.Navigate.Execute(new UnattendedInstallViewModel(HostScreen));

    private string _projectName;
    public string Projectname
    {
        get => _projectName;
        set => this.RaiseAndSetIfChanged(ref _projectName, value);
    }

    private string _outputPath;
    public string OutputPath { get => _outputPath; set => this.RaiseAndSetIfChanged(ref _outputPath, value); }

    public ReactiveCommand<Window, Unit> OpenFolder { get; }
    public Interaction<Window, string?> ShowOpenFolderDialog { get; } = new Interaction<Window, string?>();
    private async Task<Unit> OpenFolderAsync(Window window)
    {
        var fileName = await ShowOpenFolderDialog.Handle(window);

        if (fileName is not null)
        {
            // Put your logic for opening file here.
            OutputPath = fileName;
        }
        return await Task.FromResult(Unit.Default);
    }

    private bool _useProjectnameAsDirectory;
    public bool UseProjectnameAsDirectory { get => _useProjectnameAsDirectory; set => this.RaiseAndSetIfChanged(ref _useProjectnameAsDirectory, value); }

    private bool _addSolutionFile;
    public bool AddSolutionFile { get => _addSolutionFile; set => this.RaiseAndSetIfChanged(ref _addSolutionFile, value); }

    private string _umbracoVersion;
    public string UmbracoVersion { get => _umbracoVersion; set => this.RaiseAndSetIfChanged(ref _umbracoVersion, value); }

    private bool _useSQLCE;
    public bool UseSQLCE { get => _useSQLCE; set => this.RaiseAndSetIfChanged(ref _useSQLCE, value); }

    private bool _addHttps;
    public bool AddHttps { get => _addHttps; set => this.RaiseAndSetIfChanged(ref _addHttps, value); }

    private string _customEmptyScreen;
    public string CustomEmptyScreen { get => _customEmptyScreen; set => this.RaiseAndSetIfChanged(ref _customEmptyScreen, value); }
}
