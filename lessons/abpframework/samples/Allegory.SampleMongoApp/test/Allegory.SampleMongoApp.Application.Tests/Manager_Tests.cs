using Autofac.Core.Registration;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Allegory.SampleMongoApp;

public class Manager_Tests : SampleMongoAppApplicationTestBase
{
    [Fact]
    public void Should_Inject_Some_Specific_Managers()
    {
        var manager1 = GetRequiredService<SomeSpecificManager>();
        var manager2 = GetRequiredService<ISomeSpecificManager>();
        var manager3 = GetRequiredService<ISpecificManager>();
        var manager4 = GetRequiredService<IManager>();
        var manager5 = GetRequiredService<IcificManager>();

        manager1.ShouldNotBeNull();
        manager2.ShouldNotBeNull();
        manager3.ShouldNotBeNull();
        manager4.ShouldNotBeNull();
        manager5.ShouldNotBeNull();
    }

    [Fact]
    public void Should_Inject_Other_Manager()
    {
        var manager = GetRequiredService<ISomeSpecificManager>();

        manager.ShouldNotBeNull();
        Assert.Throws<ComponentNotRegisteredException>(() =>
        {
            GetRequiredService<IOtherManager>();
        });
        Assert.Throws<ComponentNotRegisteredException>(() =>
        {
            GetRequiredService<OtherManager>();
        });
    }

    [Fact]
    public void Should_Return_Multiple_Registred_Services()
    {
        var manager = GetRequiredService<IMultiManager>();
        var managers = GetRequiredService<IEnumerable<IMultiManager>>();

        managers.Count().ShouldBe(2);
        manager.GetType().ShouldBe(typeof(OtherManager));
    }

    [Fact]
    public void Should_Inject_Sample_App_Service()
    {
        var sample = GetRequiredService<SampleAppService>();
        var specificManager = sample.SpecificManager;
        var specificManager2 = sample.LazyServiceProvider.LazyGetRequiredService<ISpecificManager>();

        if(ReferenceEquals(specificManager, specificManager2))
        {
            //Same instance
        }

        var serviceProvider = sample.ServiceProvider;
        using (var scope = serviceProvider.CreateScope())
        {
            var scopeSpecificManager = scope.ServiceProvider.GetRequiredService<ISpecificManager>();
            var scopeSpecificManager2 = scope.ServiceProvider.GetRequiredService<ISpecificManager>();

            if (ReferenceEquals(scopeSpecificManager, scopeSpecificManager2)) { }
            else
            {
                //Different instance
            }
        }
    }
}
