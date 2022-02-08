namespace UmbracoProjectWizard;
public class WizardContext
{
    public string ProjectName { get; private set; }
    public WizardContext SetProjectName(string projectName)
    {
        ProjectName = projectName;
        return this;
    }

    public string OutputPath { get; private set; }
    public WizardContext SetOutputPath(string outputPath)
    {
        OutputPath = outputPath;
        return this;
    }

    public bool AddProjectNameToOutput { get; private set; }
    public WizardContext SetAddProjectNameToOutput()
    {
        AddProjectNameToOutput = true;
        return this;
    }

    public string UmbracoVersion { get; private set; }
    public WizardContext SetUmbracoVersion(string umbracoVersion)
    {
        UmbracoVersion = umbracoVersion;
        return this;
    }

    public bool UseSQLCE { get; private set; }
    public WizardContext SetUseSQLCE()
    {
        UseSQLCE = true;
        return this;
    }

    public bool UseHttpsRedirect { get; private set; }
    public WizardContext SetUseHttpsRedirect()
    {
        UseHttpsRedirect = true;
        return this;
    }

    public string EmptyScreenPath { get; private set; }
    public WizardContext SetEmptyScreenPath(string emptyScreenPath)
    {
        EmptyScreenPath = emptyScreenPath;
        return this;
    }
}
