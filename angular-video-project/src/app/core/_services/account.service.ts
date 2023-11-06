import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable, map } from "rxjs";
import { User } from "../_models";
import { environment } from "@environments/environment";
import { HttpClient } from '@angular/common/http';
import { Router } from "@angular/router";
import { userLogin } from "../_models/userLogin";
import { apiResponse } from "../_models/apiResponse";

@Injectable({ providedIn: "root" })
export class AccountService {
    private userSubject: BehaviorSubject<User | null>;
    public user: Observable<User | null>;

    constructor(private httpClient: HttpClient,
        private router: Router) {
        this.userSubject = new BehaviorSubject(
            JSON.parse(localStorage.getItem('user')!)
        );
        this.user = this.userSubject.asObservable();
    }

    public get userValue() {
        return this.userSubject.value;
    }

    login(user: userLogin): Observable<apiResponse> {
        return this.httpClient.post<apiResponse>(`${environment.apiUrl}/api/auth/login`, user);
    }

    setUser(user: any) {
        localStorage.setItem('user', JSON.stringify(user));
        this.userSubject.next(user);
    }

    setToken(token: string) {
        localStorage.setItem('token', token);
    }

    logout() {
        localStorage.removeItem('user');
        localStorage.removeItem('token');
        this.userSubject.next(null);
        this.router.navigate(['']);
    }

    register(user: User): Observable<apiResponse> {
        return this.httpClient.post<apiResponse>(`${environment.apiUrl}/api/Auth/register`, user);
    }

    addUser(user: User): Observable<apiResponse>{
        return this.httpClient.post<apiResponse>(`${environment.apiUrl}/api/Auth/addUser`, user);
    }
}