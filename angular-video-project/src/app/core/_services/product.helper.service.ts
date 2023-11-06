import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { apiResponse } from "../_models/apiResponse";
import { environment } from "@environments/environment";
import { Product } from "../_models/product";
import { ProductService } from "./products.service";
import { AccountService } from "./account.service";

@Injectable({ providedIn: "root" })
export class ProductHelperService {
    private cartCount: BehaviorSubject<number | null> = new BehaviorSubject<number | null>(null);
    private cartState = this.cartCount.asObservable();
    constructor(private productService: ProductService,
        private accountService: AccountService) {
    }

    setCartCount(count: number | null) {
        this.cartCount.next(count);
    }

    getCartCount() {
        const count = this.cartCount.getValue();
        var userId = this.accountService.userValue?.id;
        if (!count) {
            this.productService.getCartCount(userId!).subscribe({
                next: (result) => {
                    this.setCartCount(result.data);
                },
                error: () => {
                    this.setCartCount(null);
                }
            })
        }

        return this.cartState;
    }
}