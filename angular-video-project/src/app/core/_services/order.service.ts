import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { apiResponse } from "../_models/apiResponse";
import { Observable } from "rxjs";
import { environment } from "@environments/environment";

@Injectable({ providedIn: 'root' })

export class OrderService {

    constructor(private httpClient: HttpClient) { }

    getOrders(cartId: number): Observable<apiResponse> {
        return this.httpClient.get<apiResponse>(`${environment.apiUrl}/api/Order/GetOrders?cartId=${cartId}`);
    }

    getOrderDetails(sessionId: string): Observable<apiResponse> {
        return this.httpClient.get<apiResponse>(`${environment.apiUrl}/api/Order/GetOrderDetails?sSessionId=${sessionId}`);
    }
}