import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AccountService } from "../_services/account.service";
import { environment } from "@environments/environment";

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private accountService: AccountService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const user = this.accountService.userValue;
        const isLoggedIn = user?.token;
        const isApiUrl = req.url.startsWith(environment.apiUrl);
        if (isApiUrl && isLoggedIn) {
            req = req.clone({
                setHeaders: { Authorization: `Bearer ${user.token}` }
            });
        }
        return next.handle(req);
    }
}