import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';
import { errorResponse } from '../core/models/core.errorResponse.model';

export const errorHandlerInterceptor: HttpInterceptorFn = (req, next) => {
  const router = inject(Router);
 
  return next(req).pipe(
    catchError((error)=>{
      debugger;
      let errorResponse: errorResponse = {
        statusCode: error.status,
        title: error.statusText,
        message: error.message
      };
      router.navigate(['/error'], { state: {error : errorResponse}});
      
      return throwError(()=> error);
    })
  );
};
