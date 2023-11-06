import { Component, Input, OnInit, SimpleChanges } from "@angular/core";
import { AccountService } from "../_services/account.service";
import { User } from "../_models";
import { ProductService } from "../_services/products.service";
import { Observable, Subject } from "rxjs";
import { ProductHelperService } from "../_services/product.helper.service";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
    selector: 'app-header',
    templateUrl: 'header.component.html'
})

export class HeaderComponent implements OnInit {
    username: string
    currentUser: User | null
    cartCount!: number | null

    constructor(private accountService: AccountService,
        private productHelper: ProductHelperService,
        private router: Router) {
        this.currentUser = JSON.parse(localStorage.getItem('user') || '{}');
        this.username = this.currentUser?.firstName + " " + this.currentUser?.lastName;
    };

    ngOnInit() {
        this.productHelper.getCartCount().subscribe({
            next: (result) => {
                this.cartCount = result;
            },
            error: (error) => {
                console.log(error);
            }
        })
    }

    logout() {
        this.accountService.logout();
    }

    showCart(){
        this.router.navigateByUrl("/products/cart/" + this.currentUser?.id);
    }
};