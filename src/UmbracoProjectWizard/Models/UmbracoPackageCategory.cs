namespace UmbracoProjectWizard.Models;
using System.Collections.Generic;

public record UmbracoPackageCategory
{
    public UmbracoPackageCategory()
    {
        Name = string.Empty;
        Packages = new List<UmbracoPackage>();
    }

    public UmbracoPackageCategory(string name, List<UmbracoPackage> packages)
    {
        Name = name;
        Packages = packages;
    }

    public string Name { get; set; }
    public List<UmbracoPackage> Packages { get; set; }
}
