using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Allegory.StockManagement.Products;

public class Product: AggregateRoot<Guid>
{
    public string Code { get; protected set; }
    public string? Name { get; protected set; }

    protected Product()
    {
    }

    internal Product(Guid id, string code) : base(id)
    {
        SetCode(code);
    }

    internal void SetCode(string code)
    {
        Check.NotNullOrWhiteSpace(code, nameof(Code), ProductConsts.MaxCodeLength, ProductConsts.MinCodeLength);
        Code = code;
    }

    public void SetName(string? name)
    {
        Check.Length(name, nameof(Name), ProductConsts.MaxNameLength);
        Name = name;
    }
}