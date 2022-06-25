using Allegory.Module.Customers;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Allegory.Module.EntityFrameworkCore;

public static class ModuleEfCoreQueryableExtensions
{
    public static IQueryable<Customer> IncludeDetails(
        this IQueryable<Customer> queryable, 
        bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
            .Include(x => x.ContactInformations)
            .Include(x => x.Address);
    }
}
