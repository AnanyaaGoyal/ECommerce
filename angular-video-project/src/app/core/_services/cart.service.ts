import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { apiResponse } from "../_models/apiResponse";
import { environment } from "@environments/environment";
import { Observable } from "rxjs";
import { ProductQuantity } from "../_models/productQuantityModel";


@Injectable({ providedIn: 'root' })

export class CartService {

    constructor(private httpClient: HttpClient) { }

    getCartItems(userId: number): Observable<apiResponse> {
        return this.httpClient.get<apiResponse>(`${environment.apiUrl}/api/Cart/getCartItems?nUserId=${userId}`)
    }

    changeQuantity(objModel: ProductQuantity): Observable<apiResponse> {
        return this.httpClient.post<apiResponse>(`${environment.apiUrl}/api/Cart/changeQuantity`, objModel)
    }
}