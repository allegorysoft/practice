using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Allegory.StockManagement.Customers;

public class Customer : AuditedAggregateRoot<Guid>
{
    public string Code { get; protected set; }
    public string? Name { get; protected set; }

    protected Customer()
    {
    }

    internal Customer(
        Guid id,
        string code,
        string name) : base(id)
    {
        SetCode(code);
        Name = name;
    }

    internal void SetCode(string code)
    {
        Check.NotNullOrWhiteSpace(code, nameof(Code), CustomerConsts.MaxCodeLength, CustomerConsts.MinCodeLength);
        Code = code;
    }

    public void SetName(string? name)
    {
        Check.Length(name, nameof(Name), CustomerConsts.MaxNameLength);
        Name = name;
    }
}