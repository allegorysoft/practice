using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using Volo.Abp;
using Volo.Abp.VirtualFileSystem;

namespace Allegory.Module.VirtualFiles;

[RemoteService(Name = ModuleRemoteServiceConsts.RemoteServiceName)]
[Area(ModuleRemoteServiceConsts.ModuleName)]
[Route("api/module/dynamic-files")]
public class DynamicFileController : ModuleController
{
    protected IDynamicFileProvider DynamicFileProvider { get; }

    public DynamicFileController(IDynamicFileProvider dynamicFileProvider)
    {
        DynamicFileProvider = dynamicFileProvider;
    }

    [HttpGet("add-or-update")]
    public void AddOrUpdate(string value)
    {
        DynamicFileProvider.AddOrUpdate(
            new InMemoryFileInfo(
                "/dynamic-files/test.txt",
                value.GetBytes(),
                "test.txt"
            )
        );
    }
}
