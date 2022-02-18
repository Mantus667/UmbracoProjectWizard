namespace UmbracoProjectWizard.ViewModels;

using System;
using System.Reactive;
using ReactiveUI;
using ReactiveUI.Validation.Extensions;
using ReactiveUI.Validation.Helpers;
using Splat;
using UmbracoProjectWizard.Services;

public class UnattendedInstallViewModel : ReactiveValidationObject, IRoutableViewModel
{
    private readonly IWizardContextProvider _wizardContextProvider;

    public UnattendedInstallViewModel(IScreen screen)
        : this(screen, Locator.Current.GetService<IWizardContextProvider>()) { }

    public UnattendedInstallViewModel(IScreen screen, IWizardContextProvider wizardContextProvider)
    {
        ArgumentNullException.ThrowIfNull(screen, nameof(screen));
        ArgumentNullException.ThrowIfNull(wizardContextProvider, nameof(wizardContextProvider));

        HostScreen = screen;
        _wizardContextProvider = wizardContextProvider;
        _useUnattendedInstall = false;
        _friendlyName = string.Empty;
        _email = string.Empty;
        _password = string.Empty;
        _connectionString = string.Empty;
        Save = ReactiveCommand.Create(SaveImplementation, this.IsValid());

        var nameObservable = this
            .WhenAnyValue(
                vm => vm.FriendlyName,
                vm => vm.UseUnattendedInstall,
                (name, unattendedInstall) => (unattendedInstall && !string.IsNullOrWhiteSpace(name)) || !unattendedInstall);

        var emailObservable = this
            .WhenAnyValue(
                vm => vm.Email,
                vm => vm.UseUnattendedInstall,
                (email, unattendedInstall) => (unattendedInstall && !string.IsNullOrWhiteSpace(email)) || !unattendedInstall);

        var passwordObservable = this
            .WhenAnyValue(
                vm => vm.Password,
                vm => vm.UseUnattendedInstall,
                (password, unattendedInstall) => (unattendedInstall && !string.IsNullOrWhiteSpace(password)) || !unattendedInstall);

        var connectionStringObservable = this
            .WhenAnyValue(
                vm => vm.ConnectionString,
                vm => vm.UseUnattendedInstall,
                (connectionString, unattendedInstall) => (unattendedInstall && !string.IsNullOrWhiteSpace(connectionString)) || !unattendedInstall);

        this.ValidationRule(
            vm => vm.FriendlyName,
            nameObservable,
            "Name must be set for unattended install");

        this.ValidationRule(
            vm => vm.Email,
            emailObservable,
            "Email must be set for unattended install");

        this.ValidationRule(
            vm => vm.Password,
            passwordObservable,
            "Password must be set for unattended install");

        this.ValidationRule(
            vm => vm.ConnectionString,
            connectionStringObservable,
            "ConnectionString must be set for unattended install");
    }

    public string? UrlPathSegment => nameof(UnattendedInstallViewModel);

    public IScreen HostScreen { get; }

    public ReactiveCommand<Unit, Unit> Save { get; set; }
    public void SaveImplementation()
    {
        var context = _wizardContextProvider.GetWizardContext();
        context.SetUseUnattendedInstall(UseUnattendedInstall)
            .SetFriendlyName(FriendlyName)
            .SetEmail(Email)
            .SetPassword(Password)
            .SetConnectionString(ConnectionString);
        HostScreen.Router.Navigate.Execute(new PackagesViewModel(HostScreen));
    }

    private bool _useUnattendedInstall;
    public bool UseUnattendedInstall { get => _useUnattendedInstall; set => this.RaiseAndSetIfChanged(ref _useUnattendedInstall, value); }

    private string _friendlyName;
    public string FriendlyName { get => _friendlyName; set => this.RaiseAndSetIfChanged(ref _friendlyName, value); }

    private string _email;
    public string Email { get => _email; set => this.RaiseAndSetIfChanged(ref _email, value); }

    private string _password;
    public string Password { get => _password; set => this.RaiseAndSetIfChanged(ref _password, value); }

    private string _connectionString;
    public string ConnectionString { get => _connectionString; set => this.RaiseAndSetIfChanged(ref _connectionString, value); }
}
