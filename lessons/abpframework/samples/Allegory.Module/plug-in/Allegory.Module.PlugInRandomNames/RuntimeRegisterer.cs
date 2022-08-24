using Microsoft.Extensions.Hosting;
using System.Reflection;
using Volo.Abp.VirtualFileSystem;

public class RuntimeRegisterer : IHostedService
{
    protected IVirtualFileProvider VirtualFileProvider { get; }

    public RuntimeRegisterer(IVirtualFileProvider virtualFileProvider)
    {
        VirtualFileProvider = virtualFileProvider;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        await Task.CompletedTask;
    }

    private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        if (IsSuffixResource(args.Name)) return null;

        var name = $"{new AssemblyName(args.Name).Name}.dll";
        if (name == "Bogus.dll")
        {
            using (var stream = VirtualFileProvider.GetFileInfo("/Allegory/Module/PlugInRandomNames/MyResources/Bogus.dll").CreateReadStream())
            {
                return Assembly.Load(stream.GetAllBytes());
            }
        }

        throw new DllNotFoundException(name);
    }

    private bool IsSuffixResource(string argsName)
    {
        string[] fields = argsName.Split(',');
        string name = fields[0];
        string culture = fields[2];

        return name.EndsWith(".resources") && !culture.EndsWith("neutral");
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
