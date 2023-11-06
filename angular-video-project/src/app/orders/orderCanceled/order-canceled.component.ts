import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '@app/core/_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-order-canceled',
  templateUrl: 'order-canceled.component.html',
})

export class OrderCanceledComponent implements OnInit {
  public userId!: number;
  constructor(private accountService: AccountService,
    private router: Router,
    private toastrService: ToastrService) { }

  ngOnInit(): void {
    this.userId = this.accountService.userValue?.id || 0;
    this.toastrService.error("Order has been canceled");
    this.router.navigate(['products/cart/' + this.userId]);
  }
}