import { NgModule } from '@angular/core';
import { HammerModule } from "@angular/platform-browser";
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';

@NgModule({
  imports: [
    CoreModule,
    HammerModule,
  ],
  exports: [
  ],
  declarations: [
    AppComponent,
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
