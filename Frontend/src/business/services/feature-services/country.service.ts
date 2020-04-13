import { HttpBackend, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Country } from 'src/business/shared/models/country.model';

@Injectable()
export class CountryService {

  httpClient: HttpClient;
  baseUrl = 'https://restcountries.eu/rest/v2';

  constructor(
    private httpBackend: HttpBackend
  ) {
    this.httpClient = new HttpClient(this.httpBackend);
  }

  getCountries() {
    return this.httpClient.get<Country[]>(`${this.baseUrl}/all`);
  }

  getCountriesByCodes(...codes: string[]) {
    let codesFormatted = codes.join(';');
    return this.httpClient.get<Country[]>(`${this.baseUrl}/alpha?codes=${codesFormatted}`)
  }
}
