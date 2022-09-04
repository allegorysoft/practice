import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'DynamicFilter',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44320',
    redirectUri: baseUrl,
    clientId: 'DynamicFilter_App',
    responseType: 'code',
    scope: 'offline_access DynamicFilter',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44320',
      rootNamespace: 'DynamicFilter',
    },
  },
} as Environment;
