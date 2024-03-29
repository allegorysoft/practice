﻿using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Allegory.Module.Customers;

public interface ICrudCustomerGroupAppService 
    : ICrudAppService<
        CustomerGroupDto, 
        Guid,
        PagedAndSortedResultRequestDto,
        CustomerGroupCreateUpdateDto>
{

}
