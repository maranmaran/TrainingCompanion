import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Element as StripeElement, ElementOptions, ElementsOptions, StripeCardComponent, StripeService } from 'ngx-stripe';
import { Observable } from 'rxjs';
import { map, startWith, take } from 'rxjs/operators';
import { ThemeService } from 'src/business/services/shared/theme.service';
import { CurrentUserStore } from 'src/business/stores/current-user.store';
import { SubSink } from 'subsink';
import { Theme } from 'src/app/core/ng-chat/core/theme.enum';

@Component({
  selector: 'app-stripe-checkout',
  templateUrl: './stripe-checkout.component.html',
  styleUrls: ['./stripe-checkout.component.scss']
})
export class StripeCheckoutComponent implements OnInit, OnDestroy {

  countries: string[] = ["Afghanistan", "Albania", "Algeria", "AmericanSamoa", "Andorra", "Angola",
    "Anguilla", "Antarctica", "AntiguaandBarbuda", "Argentina", "Armenia", "Aruba", "Australia", "Austria", "Azerbaijan",
    "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia",
    "BosniaandHerzegovina", "Botswana", "BouvetIsland", "Brazil", "BritishIndianOceanTerritory", "BruneiDarussalam", "Bulgaria",
    "BurkinaFaso", "Burundi", "Cambodia", "Cameroon", "Canada", "CapeVerde", "CaymanIslands", "CentralAfricanRepublic", "Chad",
    "Chile", "China", "ChristmasIsland", "Cocos(Keeling)Islands", "Colombia", "Comoros", "Congo", "Congo,TheDemocraticRepublicofThe",
    "CookIslands", "CostaRica", "CoteD'ivoire", "Croatia", "Cuba", "Cyprus", "CzechRepublic", "Denmark", "Djibouti", "Dominica", "DominicanRepublic",
    "Ecuador", "Egypt", "ElSalvador", "EquatorialGuinea", "Eritrea", "Estonia", "Ethiopia", "FalklandIslands(Malvinas)", "FaroeIslands",
    "Fiji", "Finland", "France", "FrenchGuiana", "FrenchPolynesia", "FrenchSouthernTerritories", "Gabon", "Gambia", "Georgia", "Germany",
    "Ghana", "Gibraltar", "Greece", "Greenland", "Grenada", "Guadeloupe", "Guam", "Guatemala", "Guernsey", "Guinea", "Guinea-bissau", "Guyana",
    "Haiti", "HeardIslandandMcdonaldIslands", "HolySee(VaticanCityState)", "Honduras", "HongKong", "Hungary", "Iceland", "India", "Indonesia",
    "Iran,IslamicRepublicof", "Iraq", "Ireland", "IsleofMan", "Israel", "Italy", "Jamaica", "Japan", "Jersey", "Jordan", "Kazakhstan", "Kenya",
    "Kiribati", "Korea,DemocraticPeople'sRepublicof", "Korea,Republicof", "Kuwait", "Kyrgyzstan", "LaoPeople'sDemocraticRepublic", "Latvia",
    "Lebanon", "Lesotho", "Liberia", "LibyanArabJamahiriya", "Liechtenstein", "Lithuania", "Luxembourg", "Macao", "Macedonia,TheFormerYugoslavRepublicof",
    "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "MarshallIslands", "Martinique", "Mauritania", "Mauritius", "Mayotte", "Mexico",
    "Micronesia,FederatedStatesof", "Moldova,Republicof", "Monaco", "Mongolia", "Montenegro", "Montserrat", "Morocco", "Mozambique", "Myanmar",
    "Namibia", "Nauru", "Nepal", "Netherlands", "NetherlandsAntilles", "NewCaledonia", "NewZealand", "Nicaragua", "Niger", "Nigeria", "Niue",
    "NorfolkIsland", "NorthernMarianaIslands", "Norway", "Oman", "Pakistan", "Palau", "PalestinianTerritory,Occupied", "Panama", "PapuaNewGuinea",
    "Paraguay", "Peru", "Philippines", "Pitcairn", "Poland", "Portugal", "PuertoRico", "Qatar", "Reunion", "Romania", "RussianFederation", "Rwanda",
    "SaintHelena", "SaintKittsandNevis", "SaintLucia", "SaintPierreandMiquelon", "SaintVincentandTheGrenadines", "Samoa", "SanMarino", "SaoTomeandPrincipe",
    "SaudiArabia", "Senegal", "Serbia", "Seychelles", "SierraLeone", "Singapore", "Slovakia", "Slovenia", "SolomonIslands", "Somalia", "SouthAfrica",
    "SouthGeorgiaandTheSouthSandwichIslands", "Spain", "SriLanka", "Sudan", "Suriname", "SvalbardandJanMayen", "Swaziland", "Sweden", "Switzerland",
    "SyrianArabRepublic", "Taiwan,ProvinceofChina", "Tajikistan", "Tanzania,UnitedRepublicof", "Thailand", "Togo", "Tokelau", "Tonga", "TrinidadandTobago"
    , "Tunisia", "Turkey", "Turkmenistan", "TurksandCaicosIslands", "Tuvalu", "U.S.VirginIslands,U.S.", "Uganda", "Ukraine", "UnitedArabEmirates",
    "UnitedKingdom", "UnitedStates", "UnitedStatesMinorOutlyingIslands", "Uruguay", "Uzbekistan", "Vanuatu", "Venezuela", "VietNam", "VirginIslands,British",
    "WallisandFutuna", "WesternSahara", "Yemen", "Zambia", "Zimbabwe", "ÅlandIslands"];

  error: any;
  complete: Function;
  element: StripeElement;

  cardComponentColors: { icon: string, font: string, placeholder: string } = {
    icon: 'grey',
    font: 'black',
    placeholder: 'grey'
  };

  cardOptions: ElementOptions = {
    style: {
      base: {
        lineHeight: '40px',
        fontWeight: 300,
        fontFamily: '"Helvetica Neue", Helvetica, sans-serif',
        fontSize: '15px',
      }
    }
  };
  elementsOptions: ElementsOptions = {
    locale: 'en'
  };
  checkoutForm: FormGroup;

  subs = new SubSink();
  constructor(
    private currentUserStore: CurrentUserStore,
    private _stripe: StripeService,
    protected dialogRef: MatDialogRef<StripeCheckoutComponent>,
    private themeService: ThemeService
  ) {

    this.subs.add(this.themeService.theme$
      .pipe(map((theme: string) => this.themeService.getChatTheme(theme)))
      .subscribe((theme: Theme) => {
        if (theme == Theme.Dark) {
          this.cardComponentColors.icon = 'grey';
          this.cardComponentColors.font = 'white';
          this.cardComponentColors.placeholder = 'grey';
        }

        this.setCardComponentStyling();
      }));

  }

  setCardComponentStyling() {
    this.cardOptions.style.base.color = this.cardComponentColors.font;
    this.cardOptions.style.base.iconColor = this.cardComponentColors.font;
    this.cardOptions.style.base["::placeholder"].color = this.cardComponentColors.font;
  }

  ngOnInit() {
    this.createForm();
    this.getCountries();
  }

  ngOnDestroy() {
    this.subs.unsubscribe();
  }

  createForm() {
    this.checkoutForm = new FormGroup({
      name: new FormControl(this.currentUserStore.userFullName, Validators.required),
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

  filteredCountries: Observable<string[]>;
  getCountries() {
    this.filteredCountries = this.country.valueChanges
      .pipe(
        startWith(''),
        map(value => this._filter(value))
      );
  }

  private _filter(value: string): string[] {
    const filterValue = value.toString().toLowerCase();
    return this.countries.filter(option => option.toLowerCase().includes(filterValue));
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


  public onClose() {
    this.dialogRef.close('Closed');
  }

}