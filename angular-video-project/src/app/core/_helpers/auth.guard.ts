import { Injectable } from "@angular/core";
import { AccountService } from "../_services/account.service";
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from "@angular/router";

@Injectable({ providedIn: "root" })
export class AuthGuard implements CanActivate {
    constructor(private accountService: AccountService,
        private router: Router) { };

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.accountService.userValue) {
            return true;
        }

        this.router.navigate(['']), { queryParams: { returnUrl: state.url } };
        return false;
    }
}