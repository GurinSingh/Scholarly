import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutUsComponent } from './feature/user/components/about-us/about-us.component';
import { RegistrationComponent } from './pages/registration/registration.component';
import { ErrorComponent } from './pages';
import { APP_MAIN_ROUTES } from './core/constants/APP_ROUTES';

const routes: Routes = [{
  path: 'aboutus/:userName',
  component: AboutUsComponent
},
{
  path: 'user',
  loadChildren: ()=> import('./feature/user/user.module').then(m=> m.UserModule)
},
{
  path: 'registration',
  component: RegistrationComponent
},
{ path: APP_MAIN_ROUTES.ARTICLE,
  loadChildren: () => import('./feature/article/article.module').then(m => m.ArticleModule) },
{
  path: '**',
  component: ErrorComponent
}];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
