import { HTTP_INTERCEPTORS, HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreNavigationModule } from './core/core.navigation.module';
import { FeatureAboutusModule } from './feature/feature.aboutus.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ReactiveFormsModule } from '@angular/forms';
import { FeatureUserregistrationModule } from './feature/feature.userregistration.module';
import { FeatureWritecontentModule } from './feature/feature.writecontent.module';
import { CoreErrorModule } from './core/core.error.module';
import { errorHandlerInterceptor } from './interceptors/error-handler.interceptor';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, CoreNavigationModule,FeatureAboutusModule, 
    FeatureUserregistrationModule, FontAwesomeModule, ReactiveFormsModule,
    FeatureWritecontentModule, CoreErrorModule
  ],
  providers: [provideHttpClient(withInterceptors([errorHandlerInterceptor]))],
  bootstrap: [AppComponent]
})
export class AppModule { }
