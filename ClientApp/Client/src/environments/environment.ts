// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

 

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/plugins/zone-error';  // Included with Angular CLI.

export const globalEndPoint = {
  IdentityServerEndPoint: 'http://localhost:5000',
  ApiEndPoint: 'http://localhost:5001',
}

export const environment = {  
  production: false,
  environmentName: 'Development',
  apiUrl: 'https://localhost:5010/',
  Api_Key: 'xxxxxxxxxxxxxxxxxxxx'
};
