import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';
import { errorResponse } from '../../models/error/error-response';

export const ErrorHandlerInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router);
 
  return next(req).pipe(
    catchError((error)=>{
      let errorResponse: errorResponse = {
        statusCode: error.status,
        title: error.statusText,
        message: error.message
      };

      let showError:boolean = req.headers.get('show-error') == 'false';
      if(!showError)
        router.navigate(['/error'], { state: {error : errorResponse}});
      
      return throwError(()=> error);
    })
  );
};
