using System.Collections.Generic;
using Volo.Abp.Domain.Values;

namespace Allegory.Module.Customers;

public class Address : ValueObject
{
    public virtual string Country { get; protected set; }
    public virtual string City { get; protected set; }
    public virtual string Town { get; protected set; }
    public virtual string Line1 { get; protected set; }
    public virtual string Line2 { get; protected set; }

    protected Address() { }

    public Address(
        string country,
        string city,
        string town,
        string line1,
        string line2)
    {
        //TODO check properties lenght
        Country = country;
        City = city;
        Town = town;
        Line1 = line1;
        Line2 = line2;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Country;
        yield return City;
        yield return Town;
        yield return Line1;
        yield return Line2;
    }
}

