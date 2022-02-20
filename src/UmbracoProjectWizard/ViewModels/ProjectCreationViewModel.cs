namespace UmbracoProjectWizard.ViewModels;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using CliWrap;
using Material.Styles;
using ReactiveUI;
using Splat;
using UmbracoProjectWizard.Models;
using UmbracoProjectWizard.Services;

public class ProjectCreationViewModel : ReactiveObject, IRoutableViewModel
{
    private readonly IWizardContextProvider _wizardContextProvider;

    public ProjectCreationViewModel(IScreen screen)
        : this(screen, Locator.Current.GetService<IWizardContextProvider>()) { }

    public ProjectCreationViewModel(IScreen screen, IWizardContextProvider wizardContextProvider)
    {
        ArgumentNullException.ThrowIfNull(screen, nameof(screen));
        ArgumentNullException.ThrowIfNull(wizardContextProvider, nameof(wizardContextProvider));

        HostScreen = screen;
        _wizardContextProvider = wizardContextProvider;
        _errorLog = string.Empty;
        StartCreation = ReactiveCommand.Create(StartCreationImplementation);
    }

    public string? UrlPathSegment => nameof(ProjectCreationViewModel);

    private string _errorLog;
    public string ErrorLog { get => _errorLog; set => this.RaiseAndSetIfChanged(ref _errorLog, value); }

    private bool _creationStarted;
    public bool CreationStarted { get => _creationStarted; set => this.RaiseAndSetIfChanged(ref _creationStarted, value); }

    public IScreen HostScreen { get; }

    public ReactiveCommand<Unit, Task> StartCreation { get; set; }

    public ObservableCollection<CreationTaskModel> TaskItems { get; set; } = new ObservableCollection<CreationTaskModel>();

    public void CreateTasks()
    {
        TaskItems.Clear();
        var context = _wizardContextProvider.GetWizardContext();
        if (context is null)
        {
            return;
        }
        TaskItems.Add(new CreationTaskModel("Create project"));
        foreach (var package in context.SelectedPackages)
        {
            TaskItems.Add(new CreationTaskModel($"Add package {package.PackageName} to project"));
        }
        if (context.CreateSolutionFile)
        {
            TaskItems.Add(new CreationTaskModel("Creating solution"));
            TaskItems.Add(new CreationTaskModel("Add project to solution"));
        }
    }

    public async Task StartCreationImplementation()
    {
        CreationStarted = true;
        var stdOutBuffer = new StringBuilder();
        var stdErrBuffer = new StringBuilder();

        var context = _wizardContextProvider.GetWizardContext();
        if (context is null)
        {
            throw new NotSupportedException("Can't created project without existing information!");
        }

        var stepsDone = 0;
        var projectOutputPath = context.AddProjectNameToOutput ? Path.Combine(context.OutputPath, context.ProjectName) : context.OutputPath;

        var projectArguments = new List<string>
                {
                    "new",
                    "umbraco",
                    "-n",
                    context.ProjectName,
                    "-o",
                    projectOutputPath
                };

        projectArguments.AddRange(new List<string>() { "-v", context.UmbracoVersion });

        if (context.UseSQLCE)
        {
            projectArguments.Add("-ce");
        }

        if (context.UseHttpsRedirect)
        {
            projectArguments.Add("--use-https-redirect");
        }

        if (!string.IsNullOrWhiteSpace(context.EmptyScreenPath))
        {
            projectArguments.AddRange(new List<string>() { "--no-nodes-view-path", context.EmptyScreenPath });
        }

        if (context.UseUnattendedInstall)
        {
            projectArguments.AddRange(new List<string>() { "--friendly-name", context.FriendlyName });
            projectArguments.AddRange(new List<string>() { "--email", context.Email });
            projectArguments.AddRange(new List<string>() { "--password", context.Password });
            projectArguments.AddRange(new List<string>() { "--connection-string", context.ConnectionString });
        }

        TaskItems[stepsDone].IsRunning = true;
        await Cli.Wrap("dotnet")
                    .WithArguments(projectArguments, true)
                    .WithStandardOutputPipe(PipeTarget.ToStringBuilder(stdOutBuffer))
                    .WithStandardErrorPipe(PipeTarget.ToStringBuilder(stdErrBuffer))
                    .ExecuteAsync();
        TaskItems[stepsDone].IsRunning = false;
        TaskItems[stepsDone].Value = 100;

        foreach (var package in context.SelectedPackages)
        {
            stepsDone += 1;
            TaskItems[stepsDone].IsRunning = true;
            await Cli.Wrap("dotnet")
                .WithArguments(args => args
                    .Add("add")
                    .Add("package")
                    .Add(package.NugetName))
                .WithWorkingDirectory(projectOutputPath)
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(stdOutBuffer))
                .WithStandardErrorPipe(PipeTarget.ToStringBuilder(stdErrBuffer))
                .ExecuteAsync();
            TaskItems[stepsDone].IsRunning = false;
            TaskItems[stepsDone].Value = 100;
        }

        if (context.CreateSolutionFile)
        {
            var solutionArguments = new List<string>
            {
                "new",
                "sln",
                "-n",
                context.ProjectName,
                "-o",
                context.OutputPath
            };
            var projectToSolutionArguments = new List<string>
            {
                "sln",
                "add",
                projectOutputPath
            };

            stepsDone += 1;
            TaskItems[stepsDone].IsRunning = true;
            await Cli.Wrap("dotnet")
                .WithArguments(solutionArguments, true)
                .WithStandardOutputPipe(PipeTarget.ToStringBuilder(stdOutBuffer))
                .WithStandardErrorPipe(PipeTarget.ToStringBuilder(stdErrBuffer))
                .ExecuteAsync();
            TaskItems[stepsDone].IsRunning = false;
            TaskItems[stepsDone].Value = 100;

            stepsDone += 1;
            TaskItems[stepsDone].IsRunning = true;
            try
            {
                await Cli.Wrap("dotnet")
                    .WithWorkingDirectory(context.OutputPath)
                    .WithArguments(projectToSolutionArguments, true)
                    .WithStandardOutputPipe(PipeTarget.ToStringBuilder(stdOutBuffer))
                    .WithStandardErrorPipe(PipeTarget.ToStringBuilder(stdErrBuffer))
                    .ExecuteAsync();
            }
            catch (Exception ex)
            {
                ErrorLog += ex.Message;
            }
            TaskItems[stepsDone].IsRunning = false;
            TaskItems[stepsDone].Value = 100;
            ErrorLog += stdErrBuffer.ToString();

            if (string.IsNullOrWhiteSpace(_errorLog.Trim()))
            {
                SnackbarHost.Post("Creation finished successfully!");
            }
            else
            {
                SnackbarHost.Post("Errors creating project!");
            }
        }
    }
}
