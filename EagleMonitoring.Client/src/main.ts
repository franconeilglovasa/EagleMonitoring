// src/main.ts
import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppComponent } from './app/app';  // Changed from 'App' to 'AppComponent'

bootstrapApplication(AppComponent, appConfig)
  .catch((err) => console.error(err));