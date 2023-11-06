import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { OrderSuccessComponent } from "./orderSuccess/order-success.component";
import { OrderCanceledComponent } from "./orderCanceled/order-canceled.component";
import { OrderListComponent } from "./orderList/orderList.component";

const routes: Routes = [
    { path: 'success/:id', component: OrderSuccessComponent },
    { path: 'canceled', component: OrderCanceledComponent },
    {path: 'orderlist', component: OrderListComponent}
]
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})

export class OrdersRoutingModule { }