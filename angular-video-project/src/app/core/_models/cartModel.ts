import { cartItem } from './cartItem'

export class cartModel {
    cartItems!: cartItem[];
    totalCost!: number;
    orderId?: string;
    createdDate?: Date;
    invoicePdf!: string
}