import { NgModule } from "@angular/core";
import { CommonModule} from "@angular/common";
import { ReactiveFormsModule } from "@angular/forms";
import { OrderSuccessComponent } from "./orderSuccess/order-success.component";
import { OrderCanceledComponent } from "./orderCanceled/order-canceled.component";
import { OrdersRoutingModule } from "./orders-routing.module";
import { CoreModule } from "@app/core/core.module";
import { OrderListComponent } from "./orderList/orderList.component";
import { OrderComponent } from "./order/order.component";
import { OrderDetailsComponent } from "./order-details/order-details.component";

@NgModule({
    declarations: [
        OrderCanceledComponent, OrderSuccessComponent, OrderListComponent, OrderComponent, OrderDetailsComponent],
    imports: [
        CommonModule,
        ReactiveFormsModule,
        OrdersRoutingModule,
        CoreModule
    ],
    providers:[]
})

export class OrdersModule { }