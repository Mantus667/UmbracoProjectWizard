namespace UmbracoProjectWizard.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using Splat;
using UmbracoProjectWizard.Models;
using UmbracoProjectWizard.Services;
using YamlDotNet.Serialization;

internal class PackagesBootstrapper
{
    public static void Register(IMutableDependencyResolver services) => services.Register<IPackagesProvider>(() => new PackagesProvider(ReadPackagesFromDisk()));

    private static List<UmbracoPackageCategory> ReadPackagesFromDisk()
    {
        var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "AvailablePackages.yml");
        if (!File.Exists(path))
        {
            return new List<UmbracoPackageCategory>();
        }
        var fileText = File.ReadAllText(path);
        var deserializer = new DeserializerBuilder().Build();

        return deserializer.Deserialize<List<UmbracoPackageCategory>>(fileText);
    }
}
