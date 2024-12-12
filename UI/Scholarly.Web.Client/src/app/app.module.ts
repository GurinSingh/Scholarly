import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptors, withInterceptorsFromDi } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ArticleModule, UserModule } from './feature';
import { LayoutModule } from './layout';
import { SharedModule } from './shared';
import { PagesModule } from './pages';
import { ReactiveFormsModule } from '@angular/forms';
import { CoreModule } from './core/core.module';
import { ErrorHandlerInterceptor } from './core';
import { ModalModule } from 'ngx-bootstrap/modal';
import { PopoverModule } from 'ngx-bootstrap/popover';
import { RouterModule } from '@angular/router';


@NgModule({ declarations: [
        AppComponent,
    ],
    bootstrap: [AppComponent],
    imports: [BrowserModule, AppRoutingModule, ArticleModule, UserModule, RouterModule,
        SharedModule,
        LayoutModule,
        ReactiveFormsModule,
        CoreModule,
        PagesModule,
        ModalModule.forRoot(), PopoverModule.forRoot(),
        ],
    providers: [provideHttpClient(withInterceptors([ErrorHandlerInterceptor]),), provideHttpClient(withInterceptorsFromDi())] })
export class AppModule { }
