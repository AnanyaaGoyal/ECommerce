import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "@environments/environment";
import { apiResponse } from "../_models/apiResponse";

@Injectable({ providedIn: 'root' })
export class PaymentService {
    constructor(private httpClient: HttpClient) {
    }

    createOrder(cartId: number): Observable<apiResponse> {
        return this.httpClient.post<apiResponse>(`${environment.apiUrl}/api/Payment/placeOrder/${cartId}`, null)
    }

    callSuccess(checkOutId: string):Observable<apiResponse>{
        return this.httpClient.get<apiResponse>(`${environment.apiUrl}/api/Payment/success/${checkOutId}`);
    }
}