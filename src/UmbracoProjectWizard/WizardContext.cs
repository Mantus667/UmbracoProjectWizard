namespace UmbracoProjectWizard;

using System;
using System.Collections.Generic;
using UmbracoProjectWizard.Models;

public class WizardContext
{
    public WizardContext()
    {
        ProjectName = string.Empty;
        OutputPath = string.Empty;
        UmbracoVersion = string.Empty;
        EmptyScreenPath = string.Empty;
        FriendlyName = string.Empty;
        Email = string.Empty;
        Password = string.Empty;
    }

    public string ProjectName { get; private set; }
    public WizardContext SetProjectName(string projectName)
    {
        ArgumentNullException.ThrowIfNull(projectName, nameof(projectName));

        ProjectName = projectName;
        return this;
    }

    public string OutputPath { get; private set; }
    public WizardContext SetOutputPath(string outputPath)
    {
        ArgumentNullException.ThrowIfNull(outputPath, nameof(outputPath));

        OutputPath = outputPath;
        return this;
    }

    public bool AddProjectNameToOutput { get; private set; }
    public WizardContext SetAddProjectNameToOutput(bool addProjectNameToOutput)
    {
        AddProjectNameToOutput = addProjectNameToOutput;
        return this;
    }

    public bool CreateSolutionFile { get; private set; }
    public WizardContext SetCreateSolutionFile(bool createSolutionFile)
    {
        CreateSolutionFile = createSolutionFile;
        return this;
    }

    public string UmbracoVersion { get; private set; }
    public WizardContext SetUmbracoVersion(string umbracoVersion)
    {
        ArgumentNullException.ThrowIfNull(umbracoVersion, nameof(umbracoVersion));
        UmbracoVersion = umbracoVersion;
        return this;
    }

    public bool UseSQLCE { get; private set; }
    public WizardContext SetUseSQLCE(bool useSQLCE)
    {
        UseSQLCE = useSQLCE;
        return this;
    }

    public bool UseHttpsRedirect { get; private set; }
    public WizardContext SetUseHttpsRedirect(bool useHttpsRedirect)
    {
        UseHttpsRedirect = useHttpsRedirect;
        return this;
    }

    public string EmptyScreenPath { get; private set; }
    public WizardContext SetEmptyScreenPath(string emptyScreenPath)
    {
        EmptyScreenPath = emptyScreenPath;
        return this;
    }

    public bool UseUnattendedInstall { get; private set; }
    public WizardContext SetUseUnattendedInstall(bool useUnattendedInstall)
    {
        UseUnattendedInstall = useUnattendedInstall;
        return this;
    }

    public string FriendlyName { get; private set; }
    public WizardContext SetFriendlyName(string friendlyName)
    {
        FriendlyName = friendlyName;
        return this;
    }

    public string Email { get; private set; }
    public WizardContext SetEmail(string email)
    {
        Email = email;
        return this;
    }

    public string Password { get; private set; }
    public WizardContext SetPassword(string password)
    {
        Password = password;
        return this;
    }

    public string ConnectionString { get; private set; }
    public WizardContext SetConnectionString(string connectionString)
    {
        ConnectionString = connectionString;
        return this;
    }

    public IReadOnlyList<UmbracoPackage> SelectedPackages { get; private set; }
    public WizardContext SetSelectedPackages(IReadOnlyList<UmbracoPackage> selectedPackages)
    {
        SelectedPackages = selectedPackages;
        return this;
    }
}
