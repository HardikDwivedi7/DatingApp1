import { ApplicationConfig } from '@angular/core';
import { provideRouter } from '@angular/router';
// need to add manually
import {provideAnimations} from '@angular/platform-browser/animations';


import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes),
    provideHttpClient(),
    provideAnimations()
  ]
};
