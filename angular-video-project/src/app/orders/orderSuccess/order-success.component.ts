import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from '@app/core/_services/account.service';
import { PaymentService } from '@app/core/_services/payment.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-order-success',
  templateUrl: 'order-success.component.html',
})
export class OrderSuccessComponent implements OnInit {
  public checkOutId!: string;
  public userId!: number;

  constructor(private route: ActivatedRoute,
    private paymentService: PaymentService,
    private toastr : ToastrService,
    private router: Router,
    private accountService: AccountService) {
  }

  ngOnInit(): void {
    this.checkOutId = this.route.snapshot.params['id'];
    this.userId = this.accountService.userValue?.id || 0;
    this.paymentService.callSuccess(this.checkOutId).subscribe({
      next: (result) => {
        if (result.statusCode == 200) {
          this.toastr.success(result.message)
          this.router.navigate(['orders/orderlist']);
        }
      },
      error: (error) => {
        console.log(error);
      }
    })
  }

}