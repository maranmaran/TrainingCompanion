import { HttpBackend, HttpClient } from '@angular/common/http';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

export function HttpLoaderFactory(httpBackend: HttpBackend) {
  return new TranslateHttpLoader(new HttpClient(httpBackend), './assets/i18n/', '.json');
}

export function CoreHttpLoaderFactory(httpBackend: HttpBackend) {
  return new TranslateHttpLoader(new HttpClient(httpBackend), './assets/i18n/core/', '.json');
}

export function AuthorizationHttpLoaderFactory(httpBackend: HttpBackend) {
  return new TranslateHttpLoader(new HttpClient(httpBackend), './assets/i18n/authorization/', '.json');
}

export function AthleteManagementHttpLoaderFactory(httpBackend: HttpBackend) {
  return new TranslateHttpLoader(new HttpClient(httpBackend), './assets/i18n/athlete-management/', '.json');
}
