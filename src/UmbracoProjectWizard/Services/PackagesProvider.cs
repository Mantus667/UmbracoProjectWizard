namespace UmbracoProjectWizard.Services;
using System.Collections.Generic;
using UmbracoProjectWizard.Models;

public interface IPackagesProvider
{
    List<UmbracoPackageCategory> GetPackages();
}

public class PackagesProvider : IPackagesProvider
{
    private readonly List<UmbracoPackageCategory> _availablePackages;

    public PackagesProvider(List<UmbracoPackageCategory> availablePackages) => _availablePackages = availablePackages;

    public List<UmbracoPackageCategory> GetPackages() => _availablePackages;
}
