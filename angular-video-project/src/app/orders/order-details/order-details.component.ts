import { Component, Inject, OnInit } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";
import { cartModel } from "@app/core/_models/cartModel";
import { OrderService } from "@app/core/_services/order.service";

@Component({
    selector: 'app-order-details',
    templateUrl: 'order-details.component.html'
})

export class OrderDetailsComponent implements OnInit {
    public shortOrderId?: string;

    constructor(public dialogRef: MatDialogRef<OrderDetailsComponent>,
        @Inject(MAT_DIALOG_DATA) public data: cartModel,
        public orderService: OrderService) {
        this.shortOrderId = data.orderId?.substring(0,10) + '..'
    }

    ngOnInit() {
    }

    onClose(): void {
        this.dialogRef.close();
    }
}