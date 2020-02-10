import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { HammerModule } from "@angular/platform-browser";

@NgModule({
  imports: [
    CoreModule,
    HammerModule,
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
