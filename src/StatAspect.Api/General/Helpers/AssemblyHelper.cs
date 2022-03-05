namespace StatAspect.Api.General.Helpers;

public static class AssemblyHelper
{
    private const string ApiAssemblyName = "StatAspect.Api, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"; // todo: move to config
    private const string ApplicationAssemblyName = "StatAspect.Application, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"; // todo: move to config

    public static void PreloadRequiredAssemblies()
    {
        Assembly.Load(ApplicationAssemblyName);
    }

    public static Assembly GetApiAssembly()
    {
        return GetAssembly(ApiAssemblyName)!;
    }

    public static Assembly GetApplicationAssembly()
    {
        return GetAssembly(ApplicationAssemblyName)!;
    }

    private static Assembly? GetAssembly(string assemblyName)
    {
        Guard.Argument(() => assemblyName).NotNull();

        return AppDomain.CurrentDomain.GetAssemblies()
            .SingleOrDefault(a => a.FullName!
            .Equals(assemblyName, StringComparison.OrdinalIgnoreCase));
    }
}