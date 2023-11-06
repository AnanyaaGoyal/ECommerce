import { Component, OnInit } from "@angular/core";
import { orderModel } from "@app/core/_models/orderModel";
import { AccountService } from "@app/core/_services/account.service";
import { OrderService } from "@app/core/_services/order.service";

@Component({
    selector: 'app-orders',
    templateUrl: 'orderList.component.html'
})

export class OrderListComponent implements OnInit {
    public orderList!: orderModel[];

    constructor(private orderService: OrderService,
        private accountService: AccountService) { }

    ngOnInit() {
        const userId = this.accountService.userValue?.id || 0;
        this.orderService.getOrders(userId).subscribe({
            next: (result) => {
                if (result.statusCode == 200) {
                    this.orderList = result.dataList;
                }
            },
            error: (error) => {
                console.log(error);
            }
        })
    }
}