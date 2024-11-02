import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutUsComponent } from './feature/components/about-us/about-us.component';
import { UserRegistrationComponent } from './feature/components/user-registration/user-registration.component';
import { WriteContentComponent } from './feature/write-content/write-content.component';
import { ErrorComponent } from './core/components/error/error.component';

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
  path: 'writecontent',
  component: WriteContentComponent
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
