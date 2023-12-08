import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'StockManagement',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44385/',
    redirectUri: baseUrl,
    clientId: 'StockManagement_App',
    responseType: 'code',
    scope: 'offline_access StockManagement',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44385',
      rootNamespace: 'Allegory.StockManagement',
    },
  },
} as Environment;
