import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Store } from '@ngrx/store';
import { StripeCardComponent, StripeService } from 'ngx-stripe';
import { StripeCardElement, StripeCardElementOptions, StripeElementsOptions } from '@stripe/stripe-js';
import { Observable } from 'rxjs';
import { map, startWith, take } from 'rxjs/operators';
import { Theme } from 'src/business/shared/theme.enum';
import { currentUser } from 'src/ngrx/auth/auth.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { CurrentUser } from 'src/server-models/cqrs/authorization/current-user.response';
import { SubSink } from 'subsink';
import { CountryService } from './../../../../../business/services/feature-services/country.service';
import { Country } from './../../../../../business/shared/models/country.model';

@Component({
  selector: 'app-stripe-checkout',
  templateUrl: './stripe-checkout.component.html',
  styleUrls: ['./stripe-checkout.component.scss'],
  providers: [CountryService]
})
export class StripeCheckoutComponent implements OnInit, OnDestroy {

  countries: Country[];
  error: any;
  complete: Function;
  element: StripeCardElement;

  cardComponentColors: { icon: string, font: string, placeholder: string } = {
    icon: 'grey',
    font: 'black',
    placeholder: 'grey'
  };

  cardOptions: StripeCardElementOptions = {
    style: {
      base: {
        lineHeight: '40px',
        fontWeight: '300',
        fontFamily: '"Helvetica Neue", Helvetica, sans-serif',
        fontSize: '15px',
      }
    }
  };
  elementsOptions: StripeElementsOptions = {
    locale: 'en'
  };
  checkoutForm: FormGroup;

  private currentUser: CurrentUser;

  subs = new SubSink();
  constructor(
    private _stripe: StripeService,
    private dialogRef: MatDialogRef<StripeCheckoutComponent>,
    private store: Store<AppState>,
    private _countryService: CountryService
  ) {
  }

  ngOnInit() {

    this.store.select(currentUser).pipe(take(1))
      .subscribe(user => {
        this.currentUser = user

        if (user.userSetting.theme == Theme.Dark) {
          this.cardComponentColors.icon = 'grey';
          this.cardComponentColors.font = 'white';
          this.cardComponentColors.placeholder = 'grey';
        }

        this.setCardComponentStyling();
        this.createForm();
      });

    this._countryService.getCountries().pipe(take(1))
      .subscribe(
        countries => (this.countries = countries as Country[], this.getCountries()),
        err => console.log(err)
      );

  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  setCardComponentStyling() {
    this.cardOptions.style.base.color = this.cardComponentColors.font;
    this.cardOptions.style.base.iconColor = this.cardComponentColors.font;
    // this.cardOptions.style.base["::placeholder"].color = this.cardComponentColors.font;
  }

  createForm() {
    this.checkoutForm = new FormGroup({
      name: new FormControl(this.currentUser.fullName, Validators.required),
      phone: new FormControl('', Validators.required),
      address: new FormControl('', Validators.required),
      city: new FormControl('', Validators.required),
      state: new FormControl('', Validators.required),
      country: new FormControl('', Validators.required)
    });
  }

  get name(): AbstractControl { return this.checkoutForm.get('name'); }
  get phone(): AbstractControl { return this.checkoutForm.get('phone'); }
  get address(): AbstractControl { return this.checkoutForm.get('address'); }
  get city(): AbstractControl { return this.checkoutForm.get('city'); }
  get state(): AbstractControl { return this.checkoutForm.get('state'); }
  get country(): AbstractControl { return this.checkoutForm.get('country'); }

  filteredCountries: Observable<Country[]>;
  getCountries() {
    this.filteredCountries = this.country.valueChanges
      .pipe(
        startWith(''),
        map(value => this._filter(value))
      );
  }

  private _filter(value: string): Country[] {
    const filterValue = value.toString().toLowerCase();
    return this.countries.filter(option => option.name.toLowerCase().includes(filterValue));
  }

  @ViewChild(StripeCardComponent, { static: true }) card: StripeCardComponent;
  getCardToken() {
    const card = this.card.getCard();
    const data = {
      name: this.name.value,
      address_line1: this.address.value,
      address_city: this.city.value,
      address_state: this.state.value,
      address_country: this.country.value,
    };

    try {
      this._stripe.createToken(card, data)
        .pipe(take(1))
        .subscribe(
          (result) => {
            if (result.error) {
              this.handleCardError();
              return;
            }

            // Pass token to service for purchase.
            this.dialogRef.close(result);
          },
          (err) => this.handleCardError());
    }
    catch (error) {
      this.handleCardError();
    }

  }

  handleCardError() {
    this.error = 'Something went wrong please update card information';
  }

  onClose() {
    this.dialogRef.close('Closed');
  }

}
