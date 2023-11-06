import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Operation } from "@app/core/_enums/Operation";
import { apiResponse } from "@app/core/_models/apiResponse";
import { cartItem } from "@app/core/_models/cartItem";
import { ProductQuantity } from "@app/core/_models/productQuantityModel";
import { AccountService } from "@app/core/_services/account.service";
import { CartService } from "@app/core/_services/cart.service";
import { PaymentService } from "@app/core/_services/payment.service";
import { ProductHelperService } from "@app/core/_services/product.helper.service";
import { environment } from "@environments/environment";
import { Stripe, loadStripe } from '@stripe/stripe-js';

@Component({
    selector: 'app-cart',
    templateUrl: 'cart.component.html'
})

export class CartComponent implements OnInit {
    public totalCost!: number
    public cartItems!: cartItem[]
    public isCartEmpty: boolean = false
    public userId!: number
    public cartId!: number
 private stripePromise?: Promise<Stripe | null>;

    constructor(private cartService: CartService,
        private accountService: AccountService,
        private productHelper: ProductHelperService,
        private route: ActivatedRoute,
        private paymentService: PaymentService) {
    }

    ngOnInit() {
        this.userId = this.route.snapshot.params['id'];
        this.cartId = this.userId;
        this.getCartItems();
    }

    getCartItems() {
        this.cartService.getCartItems(this.userId).subscribe({
            next: (result) => {
                this.cartItems = result.data.cartItems;
                this.totalCost = result.data.totalCost
                if (this.cartItems.length == 0) {
                    this.isCartEmpty = true;
                }
            },
            error: (error) => {
                console.log(error);
            }
        })
    }

    shortenText(text: string) {
        if (text.length > 300) {
            text = text.substring(0, 300) + "..."
        }
        return text;
    }

    addQuantity(productId: number) {
        const objModel: ProductQuantity = {
            productId: productId,
            cartId: this.userId,
            operation: Operation.Add
        }

        this.cartService.changeQuantity(objModel).subscribe({
            next: (result) => {
                this.getCartItems();
                this.productHelper.setCartCount(null);
                this.productHelper.getCartCount().subscribe({
                    error: (error) => {
                        console.log(error)
                    }
                })
            },
            error: (error) => {
                console.log(error);
            }
        })
    }

    decreaseQuantity(productId: number) {
        const objModel: ProductQuantity = {
            productId: productId,
            cartId: this.userId,
            operation: Operation.Decrease
        }

        this.cartService.changeQuantity(objModel).subscribe({
            next: (result) => {
                this.getCartItems();
                this.productHelper.setCartCount(null);
                this.productHelper.getCartCount().subscribe({
                    error: (error) => {
                        console.log(error)
                    }
                })
            },
            error: (error) => {
                console.log(error);
            }
        }) 
    }

    async placeOrder() {
        await this.pay(environment.stripe.publicKey);
    }

    async pay(stripePublicKey: string) {
        this.stripePromise = loadStripe(stripePublicKey);
        const stripe = await this.stripePromise;
        this.paymentService.createOrder(this.cartId).subscribe((response: apiResponse)=>{
            stripe?.redirectToCheckout({sessionId: response.data});
        });
    }
};