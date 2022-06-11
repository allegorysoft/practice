import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'Module',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44367',
    redirectUri: baseUrl,
    clientId: 'Module_App',
    responseType: 'code',
    scope: 'offline_access Module role email openid profile',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44367',
      rootNamespace: 'Allegory.Module',
    },
    Module: {
      url: 'https://localhost:44369',
      rootNamespace: 'Allegory.Module',
    },
  },
} as Environment;
