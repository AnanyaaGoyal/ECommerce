import { Component, Input } from "@angular/core";
import { Product } from "@app/core/_models/product";
import { AccountService } from "@app/core/_services/account.service";
import { ProductHelperService } from "@app/core/_services/product.helper.service";
import { ProductService } from "@app/core/_services/products.service";
import { ToastrService } from "ngx-toastr";

@Component({
    selector: 'app-product',
    templateUrl: 'product.component.html'
})

export class ProductComponent {
    @Input() productData!: Product

    constructor(private productService: ProductService,
        private accountService: AccountService,
        private toastrService: ToastrService,
        private productHelper: ProductHelperService) {
    }

    addToCart(productId: number) {
        const userId = this.accountService.userValue?.id || 0;
        this.productService.addToCart(productId, userId).subscribe({
            next: (result) => {
                this.productHelper.setCartCount(null);
                this.productHelper.getCartCount().subscribe({
                    next: (result) => {
                    },
                    error: (error) => {
                        console.log(error);
                    }
                })
            },
            error: (error) => {
                console.log(error);
            }
        })
    }

    shortenDescription(text: string) {
        if (text.length > 100) {
            text = text.substring(0, 100) + "..."
        }
        return text;
    }
};