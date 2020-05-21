// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  name: 'development',
  production: false,
  showStackTrace: true,

  apiUrl: 'https://localhost:44304/api/',
  apiUrlNoSSL: 'http://localhost:44302/api/',

  notificationHubUrl: 'https://localhost:44304/api/notifications-hub',
  notificationHubUrlNoSSL: 'http://localhost:44302/api/notifications-hub',

  feedHubUrl: 'https://localhost:44304/api/feed-hub',
  feedHubUrlNoSSL: 'http://localhost:44302/api/feed-hub',

  chatHubUrl: 'https://localhost:44304/api/chat-hub',
  chatHubUrlNoSSL: 'http://localhost:44302/api/chat-hub',

  stripePublishableKey: 'pk_test_zScuAdL8ZCULuob3sbgWfnzw',
};



/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
