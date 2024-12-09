import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutUsComponent } from './feature/components/about-us/about-us.component';
import { UserRegistrationComponent } from './feature/components/user-registration/user-registration.component';
import { ErrorComponent } from './core/components/error/error.component';
import { WriteArticleComponent } from './feature/components/write-article/write-article.component';
import { ViewArticleComponent } from './feature/components/view-article/view-article.component';

const routes: Routes = [{
  path: 'aboutus/:userName',
  component: AboutUsComponent
},
{
  path: 'aboutus',
  component: AboutUsComponent
},
{
  path: 'registration',
  component: UserRegistrationComponent
},
{
  path: 'write/article',
  component: WriteArticleComponent
},
{
  path: 'view/article/:selector',
  component: ViewArticleComponent
},
{
  path: '**',
  component: ErrorComponent
}];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
