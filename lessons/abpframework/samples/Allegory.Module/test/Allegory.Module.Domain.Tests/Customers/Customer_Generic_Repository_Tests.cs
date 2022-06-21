using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Xunit;

namespace Allegory.Module.Customers;

public class Customer_Generic_Repository_Tests : ModuleDomainTestBase
{
    private IGuidGenerator _guidGenerator;
    private IRepository<Customer, Guid> _repository;

    public Customer_Generic_Repository_Tests()
    {
        _guidGenerator = GetRequiredService<IGuidGenerator>();
        _repository = GetRequiredService<IRepository<Customer, Guid>>();
    }

    [Fact]
    public async Task Should_List_Customers()
    {
        var list = await _repository.GetListAsync();

        list.ShouldNotBeNull();
    }

    [Fact]
    public async Task Should_Paged_List_Customers()
    {
        var pagedList = await _repository.GetPagedListAsync(0, 2, nameof(Customer.Name));

        pagedList.ShouldNotBeNull();
        pagedList.Count.ShouldBe(2);
    }

    [Fact]
    public async Task Should_Count_Customers()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var customerCount = await _repository.CountAsync();

            customerCount.ShouldBe(3);
        });
    }

    [Fact]
    public async Task Should_Get_Customer()
    {
        await Assert.ThrowsAsync<EntityNotFoundException>(//Kayıt bulunamazsa
            async () => await _repository.GetAsync(Guid.Empty));

        await Assert.ThrowsAsync<InvalidOperationException>(//Birden çok kayıt dönerse
            async () => await _repository.GetAsync(c => c.Id != Guid.Empty));

        var customerId = await WithUnitOfWorkAsync<Guid>(
            async () => (await _repository.FirstOrDefaultAsync()).Id);
        var customer = await _repository.GetAsync(customerId);
        customer.ShouldNotBeNull();
    }

    [Fact]
    public async Task Should_Find_Customer()
    {
        Assert.Null(await _repository.FindAsync(Guid.Empty));

        await Assert.ThrowsAsync<InvalidOperationException>(//Birden çok kayıt dönerse
            async () => await _repository.FindAsync(c => c.Id != Guid.Empty));

        var customerId = await WithUnitOfWorkAsync<Guid>(
            async () => (await _repository.FirstOrDefaultAsync()).Id);
        var customer = await _repository.FindAsync(customerId);
        customer.ShouldNotBeNull();
    }

    [Fact]
    public async Task Should_Insert_Customer()
    {
        var customer = new Customer(_guidGenerator.Create(), "Ahmet Faruk", "ULU");
        await _repository.InsertAsync(customer);

        var createdCustomer = await _repository.GetAsync(customer.Id);

        createdCustomer.Name.ShouldBe("Ahmet Faruk");
    }

    [Fact]
    public async Task Should_Update_Customer()
    {
        var customer = new Customer(_guidGenerator.Create(), "Ahmet Faruk", "ULU");
        await _repository.InsertAsync(customer);

        customer.SetName("Masum");
        await _repository.UpdateAsync(customer);

        var updatedCustomer = await _repository.GetAsync(customer.Id);
        updatedCustomer.Name.ShouldBe("Masum");
    }

    [Fact]
    public async Task Should_Delete_Customer()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            var customerCount = await _repository.CountAsync();
            customerCount.ShouldBe(3);
        });

        await _repository.DeleteAsync(x => x.Id != Guid.Empty);

        await WithUnitOfWorkAsync(async () =>
        {
            var customerCount = await _repository.CountAsync();
            customerCount.ShouldBe(0);
        });
    }

    [Fact]
    public async Task Should_Create_Many_Customer()
    {
        var customers = new List<Customer>()
        {
            new Customer(_guidGenerator.Create(),"Ahmet Faruk","ULU"),
            new Customer(_guidGenerator.Create(),"Masum","ULU")
        };

        await _repository.InsertManyAsync(customers);

        await WithUnitOfWorkAsync(async () =>
        {
            var customerCount = await _repository.CountAsync();
            customerCount.ShouldBe(5);
        });

        //_repository.UpdateManyAsync()
        //_repository.DeleteManyAsync()
    }
}
