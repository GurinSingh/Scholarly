import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptors, withInterceptorsFromDi } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreNavigationModule } from './core/core.navigation.module';
import { FeatureAboutusModule } from './feature/feature.aboutus.module';
import { ReactiveFormsModule } from '@angular/forms';
import { FeatureUserregistrationModule } from './feature/feature.userregistration.module';
import { CoreErrorModule } from './core/core.error.module';
import { errorHandlerInterceptor } from './interceptors/error-handler.interceptor';
import { FeatureWritearticleModule } from './feature/feature.writearticle.module';
import { FeatureViewarticleModule } from './feature/feature.viewarticle.module';
import { ModalModule } from 'ngx-bootstrap/modal';
import { ImageUploaderComponent } from './shared/image-uploader/image-uploader.component';
import { PopoverModule } from 'ngx-bootstrap/popover';


@NgModule({ declarations: [
        AppComponent
    ],
    bootstrap: [AppComponent],
    imports: [BrowserModule, AppRoutingModule, CoreNavigationModule, FeatureAboutusModule,
        FeatureUserregistrationModule, ReactiveFormsModule,
        FeatureWritearticleModule, CoreErrorModule, FeatureViewarticleModule,
        ModalModule.forRoot(), ImageUploaderComponent, PopoverModule.forRoot(),
        ],
    providers: [provideHttpClient(withInterceptors([errorHandlerInterceptor]),), provideHttpClient(withInterceptorsFromDi())] })
export class AppModule { }
