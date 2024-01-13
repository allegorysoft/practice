import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'StockManagement',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44374/',
    redirectUri: baseUrl,
    clientId: 'StockManagement_App',
    responseType: 'code',
    scope: 'offline_access StockManagement',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44374',
      rootNamespace: 'Allegory.StockManagement',
    },
    StockManagement: {
      url: 'https://localhost:44309',
      rootNamespace: 'Allegory.StockManagement',
    },
  },
} as Environment;
