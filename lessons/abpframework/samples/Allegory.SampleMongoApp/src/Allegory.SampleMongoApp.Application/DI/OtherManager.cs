﻿using Volo.Abp.DependencyInjection;

namespace Allegory.SampleMongoApp.DI;

[ExposeServices(typeof(ISomeSpecificManager))]
public class OtherManager : ITransientDependency,
    ISomeSpecificManager,//Registered with ExposeServiceAttribute
    IMultiManager, //Manuel registered
    IOtherManager//Not registered because IncludeDefault = false
{

}
