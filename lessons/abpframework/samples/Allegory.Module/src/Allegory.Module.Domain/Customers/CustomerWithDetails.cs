using System;
using System.Collections.Generic;
using Volo.Abp.Data;

namespace Allegory.Module.Customers;

public class CustomerWithDetails : IHasExtraProperties
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string CustomerGroupCode { get; set; }
    public ICollection<ContactInformation> ContactInformations { get; set; }//TODO Should create ContactInformationWithDetails model?
    public Address Address { get; set; }

    public ExtraPropertyDictionary ExtraProperties { get; set; }
}
