import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent, RegisterComponent } from './account';
import { AuthGuard } from './core/_helpers/auth.guard';
import { ConfirmationComponent } from './account/confirmation.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'confirm/:key', component: ConfirmationComponent },
  { path: 'products', loadChildren: () => import('././products/products.module').then(m => m.ProductsModule), canActivate: [AuthGuard] },
  { path: 'orders', loadChildren: () => import('./orders/orders.module').then(m => m.OrdersModule), canActivate: [AuthGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
