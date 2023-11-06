import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { apiResponse } from "../_models/apiResponse";
import { environment } from "@environments/environment";
import { Product } from "../_models/product";

@Injectable({ providedIn: "root" })
export class ProductService {
    private result!: Observable<apiResponse>;

    constructor(private httpClient: HttpClient) {
    }

    getAllProducts(): Observable<apiResponse> {
        this.result = this.httpClient.get<apiResponse>(`${environment.apiUrl}/api/Product/getProducts`);
        return this.result;
    }

    addToCart(productId: number, userId: number): Observable<apiResponse> {
        return this.httpClient.get<apiResponse>(`${environment.apiUrl}/api/Product/addToCart?productId=${productId}&userId=${userId}`)
    }

    getCartCount(userId: number){
        return this.httpClient.get<apiResponse>(`${environment.apiUrl}/api/Product/getCartCount?nUserId=${userId}`)
    }
}