namespace UmbracoProjectWizard.Models;
public record UmbracoPackage
{
    public UmbracoPackage()
    {
        NugetName = string.Empty;
        PackageName = string.Empty;
    }

    public UmbracoPackage(string nugetName, string packageName)
    {
        NugetName = nugetName;
        PackageName = packageName;
    }

    public string NugetName { get; set; }
    public string PackageName { get; set; }
}
