import { Component, Input, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { orderModel } from "@app/core/_models/orderModel";
import { OrderDetailsComponent } from "../order-details/order-details.component";
import { OrderService } from "@app/core/_services/order.service";
import { cartModel } from "@app/core/_models/cartModel";

@Component({
    selector: 'app-order',
    templateUrl: 'order.component.html'
})

export class OrderComponent implements OnInit {
    public objModel!: cartModel;
    @Input() order!: orderModel;

    constructor(public dialog: MatDialog,
        public orderService: OrderService) { }

    ngOnInit(): void {

    }

    openDialog(sessionId: string) {
        this.orderService.getOrderDetails(sessionId).subscribe({
            next: (result) => {
                if (result.statusCode == 200) {
                    this.objModel = result.data;
                    const dialogRef = this.dialog.open(OrderDetailsComponent, {
                        data: this.objModel,
                        id: 'idOrderDetailsDialog'
                    });
                }
            },
            error: (error) => {
                console.log(error);
            }
        })
    }
}