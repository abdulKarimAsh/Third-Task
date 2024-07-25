import { Routes } from '@angular/router';
import { BookComponent } from './book/book.component';

export const routes: Routes = [
  { path: 'StackOverFlow', loadComponent: () => import("./stack-over-flow/stack-over-flow.component").then(so => so.StackOverFlowComponent) },
  { path: 'Books', component: BookComponent },
  { path: '', component: BookComponent }
];
