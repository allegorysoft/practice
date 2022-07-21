using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Allegory.Module.Customers;

public class AddressDto : EntityDto
{
    [Required] public string Country { get; set; }
    [Required] public string City { get; set; }
    [Required] public string Town { get; set; }
    [Required] public string Line1 { get; set; }
    [Required] public string Line2 { get; set; }
}
