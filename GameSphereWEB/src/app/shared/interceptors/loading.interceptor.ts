import { HttpInterceptorFn } from '@angular/common/http';
import { LoaderService } from '../../services/misc/loader.service';
import { inject } from '@angular/core';
import { finalize } from 'rxjs';

export const loadingInterceptor: HttpInterceptorFn = (req, next) => {
  const loader = inject(LoaderService);

  loader.setLoading(true);

  // once its done stop the loader
  return next(req).pipe(finalize(() => loader.setLoading(false)));
};
