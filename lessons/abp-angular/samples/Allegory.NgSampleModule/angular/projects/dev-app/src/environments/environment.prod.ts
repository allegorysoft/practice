import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl: 'http://localhost:4200/',
    name: 'NgSampleModule',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44359/',
    redirectUri: baseUrl,
    clientId: 'NgSampleModule_App',
    responseType: 'code',
    scope: 'offline_access NgSampleModule',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44359',
      rootNamespace: 'Allegory.NgSampleModule',
    },
    NgSampleModule: {
      url: 'https://localhost:44342',
      rootNamespace: 'Allegory.NgSampleModule',
    },
  },
} as Environment;
