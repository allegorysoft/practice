/* This file is automatically generated by ABP framework to use MVC Controllers from javascript. */


// module module

(function(){

  // controller allegory.module.samples.sample

  (function(){

    abp.utils.createNamespace(window, 'allegory.module.samples.sample');

    allegory.module.samples.sample.get = function(ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/Module/sample',
        type: 'GET'
      }, ajaxParams));
    };

    allegory.module.samples.sample.getAuthorized = function(ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/Module/sample/authorized',
        type: 'GET'
      }, ajaxParams));
    };

  })();

  // controller allegory.module.customers.customer

  (function(){

    abp.utils.createNamespace(window, 'allegory.module.customers.customer');

    allegory.module.customers.customer.get = function(id, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/module/customers/' + id + '',
        type: 'GET'
      }, ajaxParams));
    };

    allegory.module.customers.customer.getList = function(input, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/module/customers' + abp.utils.buildQueryString([{ name: 'filter', value: input.filter }, { name: 'sorting', value: input.sorting }, { name: 'skipCount', value: input.skipCount }, { name: 'maxResultCount', value: input.maxResultCount }]) + '',
        type: 'GET'
      }, ajaxParams));
    };

    allegory.module.customers.customer.create = function(input, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/module/customers',
        type: 'POST',
        data: JSON.stringify(input)
      }, ajaxParams));
    };

    allegory.module.customers.customer.update = function(id, input, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/module/customers/' + id + '',
        type: 'PUT',
        data: JSON.stringify(input)
      }, ajaxParams));
    };

    allegory.module.customers.customer['delete'] = function(id, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/module/customers/' + id + '',
        type: 'DELETE',
        dataType: null
      }, ajaxParams));
    };

  })();

  // controller allegory.module.customers.customerGroup

  (function(){

    abp.utils.createNamespace(window, 'allegory.module.customers.customerGroup');

    allegory.module.customers.customerGroup.get = function(id, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/module/customer-groups/' + id + '',
        type: 'GET'
      }, ajaxParams));
    };

    allegory.module.customers.customerGroup.getByCode = function(code, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/module/customer-groups/by-code' + abp.utils.buildQueryString([{ name: 'code', value: code }]) + '',
        type: 'GET'
      }, ajaxParams));
    };

    allegory.module.customers.customerGroup.getList = function(input, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/module/customer-groups' + abp.utils.buildQueryString([{ name: 'skipCount', value: input.skipCount }, { name: 'maxResultCount', value: input.maxResultCount }, { name: 'sorting', value: input.sorting }]) + '',
        type: 'GET'
      }, ajaxParams));
    };

    allegory.module.customers.customerGroup.create = function(input, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/module/customer-groups',
        type: 'POST',
        data: JSON.stringify(input)
      }, ajaxParams));
    };

    allegory.module.customers.customerGroup.update = function(id, input, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/module/customer-groups/' + id + '',
        type: 'PUT',
        data: JSON.stringify(input)
      }, ajaxParams));
    };

    allegory.module.customers.customerGroup['delete'] = function(id, ajaxParams) {
      return abp.ajax($.extend(true, {
        url: abp.appPath + 'api/module/customer-groups/' + id + '',
        type: 'DELETE',
        dataType: null
      }, ajaxParams));
    };

  })();

})();

