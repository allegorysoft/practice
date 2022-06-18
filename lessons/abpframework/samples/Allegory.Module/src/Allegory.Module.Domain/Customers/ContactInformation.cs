using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Allegory.Module.Customers;

public class ContactInformation : Entity
{
    public virtual Guid CustomerId { get; protected set; }
    public virtual string Name { get; protected set; }
    public virtual ContactInformationType Type { get; set; }
    public virtual string Value { get; protected set; }

    protected ContactInformation() { }

    internal ContactInformation(
        Guid customerId,
        string name,
        ContactInformationType type,
        string value)
    {
        CustomerId = customerId;
        SetName(name);
        Type = type;
        SetValue(value);
    }

    internal virtual void SetName(string name)
    {
        Check.NotNullOrWhiteSpace(name, nameof(Name), ContactInformationConsts.MaxNameLength);
        Name = name;
    }

    public virtual void SetValue(string value)
    {
        Check.NotNullOrWhiteSpace(value, nameof(Value), ContactInformationConsts.MaxValueLength);
        Value = value;
    }

    public override object[] GetKeys()
    {
        return new object[] { CustomerId, Name };
    }
}
