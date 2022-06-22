using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Allegory.Module.Customers;

public class Customer : AggregateRoot<Guid>
{
    public virtual string Name { get; protected set; }
    public virtual string Surname { get; protected set; }
    public virtual Guid? CustomerGroupId { get; internal set; }
    public virtual ICollection<ContactInformation> ContactInformations { get; protected set; }
    public virtual Address Address { get; set; }

    protected Customer() { }

    public Customer(
        Guid id,
        string name,
        string surname) : base(id)
    {
        SetName(name);
        SetSurname(surname);
        ContactInformations = new Collection<ContactInformation>();
    }

    public virtual void SetName(string name)
    {
        Check.NotNullOrWhiteSpace(name, nameof(Name), CustomerConsts.MaxNameLength);
        Name = name;
    }

    public virtual void SetSurname(string surname)
    {
        Check.NotNullOrWhiteSpace(surname, nameof(Surname), CustomerConsts.MaxSurnameLength);
        Surname = surname;
    }

    public virtual ContactInformation AddContactInformation(
        string name,
        ContactInformationType type,
        string value)
    {
        if (ContactInformations.Any(c => c.Name == name))
            throw new UserFriendlyException($"{name} isminde iletişim bilgisi kayıtlı");

        var contactInformation = new ContactInformation(Id, name, type, value);
        ContactInformations.Add(contactInformation);

        return contactInformation;
    }
}