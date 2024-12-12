import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ViewArticleComponent } from './components/view-article/view-article.component';
import { WriteArticleComponent } from './components/write-article/write-article.component';
import { APP_SUB_ROUTES } from '../../core/constants/APP_ROUTES';

const routes: Routes = [
  { 
    path: APP_SUB_ROUTES.VIEW_ARTICLE.ROUTE+ '/:selector',
    component: ViewArticleComponent
  },
  {
    path: APP_SUB_ROUTES.WRITE_ARTICLE.ROUTE,
    component: WriteArticleComponent
  }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ArticleRoutingModule { }
