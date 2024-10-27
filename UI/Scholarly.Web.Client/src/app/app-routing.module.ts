import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutUsComponent } from './feature/components/about-us/about-us.component';
import { UserRegistrationComponent } from './feature/components/user-registration/user-registration.component';

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
}];


@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
