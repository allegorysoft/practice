using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Volo.Abp;
using Volo.Abp.VirtualFileSystem;

namespace Allegory.Module.VirtualFiles;

[RemoteService(Name = ModuleRemoteServiceConsts.RemoteServiceName)]
[Area(ModuleRemoteServiceConsts.ModuleName)]
[Route("api/module/virtual-files")]
public class VirtualFileController : ModuleController
{
    protected IVirtualFileProvider VirtualFileProvider { get; }

    public VirtualFileController(IVirtualFileProvider virtualFileProvider)
    {
        VirtualFileProvider = virtualFileProvider;
    }

    [HttpGet("directory-contents")]
    public IActionResult GetDirectoryContents(string path = "/")
    {
        return Ok(VirtualFileProvider.GetDirectoryContents(path));
    }

    [HttpGet("read-as-string")]
    public string GetFileInfo(string path)
    {
        return VirtualFileProvider.GetFileInfo(path).ReadAsString();
    }
}
