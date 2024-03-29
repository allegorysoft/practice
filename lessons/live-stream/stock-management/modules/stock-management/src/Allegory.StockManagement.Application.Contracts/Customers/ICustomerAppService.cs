﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Allegory.StockManagement.Customers;

public interface ICustomerAppService : IApplicationService
{
    Task<IReadOnlyList<CustomerDto>> GetListAsync();
    Task<CustomerDto> GetAsync(Guid id);
    Task<CustomerDto> GetByCodeAsync(string code);
    Task<CustomerDto> CreateAsync(CustomerCreateDto input);
}