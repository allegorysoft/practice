import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'StockManagementApp',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44324/',
    redirectUri: baseUrl,
    clientId: 'StockManagementApp_App',
    responseType: 'code',
    scope: 'offline_access StockManagementApp',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44324',
      rootNamespace: 'Allegory.StockManagementApp',
    },
  },
} as Environment;
