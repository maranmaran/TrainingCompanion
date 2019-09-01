// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  name: 'development',
  production: false,
  showStackTrace: true,
  apiUrl: 'http://localhost:50000/api/',
  notificationHubUrl: 'http://localhost:50000/api/notifications-hub',
  chatHubUrl: 'http://localhost:50000/api/chat-hub',
  stripePublishableKey: 'pk_test_zScuAdL8ZCULuob3sbgWfnzw',
  planColors: [
      'linear-gradient(45deg, #dd5e89, #f7bb97)',
      'linear-gradient(45deg, #00b4db, #0083b0)',
      'linear-gradient(45deg, #4568dc, #b06ab3)'
    ],
  
};



/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
