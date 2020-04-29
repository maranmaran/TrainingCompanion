import { NgModule } from '@angular/core';
import { HammerModule } from "@angular/platform-browser";
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { VelocityHomeComponent } from './features/velocity/velocity-home/velocity-home.component';

@NgModule({
  imports: [
    CoreModule,
    HammerModule,
  ],
  exports: [
  ],
  declarations: [
    AppComponent,
    VelocityHomeComponent,
  ],
  providers: [
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
