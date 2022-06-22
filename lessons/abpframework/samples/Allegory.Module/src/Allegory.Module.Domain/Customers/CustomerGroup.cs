using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Allegory.Module.Customers;

public class CustomerGroup : AggregateRoot<Guid>
{
    public virtual string Code { get; protected set; }
    public virtual string Description { get; protected set; }

    protected CustomerGroup() { }

    internal CustomerGroup(
        Guid id,
        string code,
        string description = default) : base(id)
    {
        SetCode(code);
        SetDescription(description);
    }

    internal virtual void SetCode(string code)
    {
        Check.NotNullOrWhiteSpace(code, nameof(Code), CustomerGroupConsts.MaxCodeLength);
        Code = code;
    }

    public virtual void SetDescription(string description)
    {
        Check.Length(description, nameof(Description), CustomerGroupConsts.MaxDescriptionLength);
        Description = description;
    }
}
