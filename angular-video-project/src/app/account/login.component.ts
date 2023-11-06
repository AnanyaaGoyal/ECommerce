import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { AccountService } from "../core/_services/account.service";
import { first } from "rxjs";
import { ActivatedRoute, Router } from "@angular/router";
import { userLogin } from "@app/core/_models/userLogin";
import { ToastrService } from "ngx-toastr";

@Component({
    selector: 'app-login',
    templateUrl: 'login.component.html'
})

export class LoginComponent implements OnInit {
    form!: FormGroup
    submitted = false;

    constructor(
        private formBuilder: FormBuilder,
        private accountService: AccountService,
        private route: ActivatedRoute,
        private router: Router,
        private toastr : ToastrService
    ) { }

    ngOnInit() {
        this.form = this.formBuilder.group({
            username: ['veerna128@gmail.com', Validators.required],
            password: ['Admin@123', Validators.required]
        })
    }

    get f() {
        return this.form.controls;
    }

    onSubmit() {
        this.submitted = true;
        if (this.form.invalid)
            return;
            this.accountService.login(this.form.value).pipe(first()).subscribe({
            next: (result) => {
                if(result.statusCode == 200){
                    this.accountService.setUser(result.data);
                    const returnUrl = this.route.snapshot.queryParams['returnUrl'] || ['products'];
                    this.router.navigate(returnUrl);
                    this.toastr.success(result.message);
                }
               else{
                this.toastr.error(result.message);
               }
            },
            error: (error)=>{
                console.log(error);
            }
        })
    }
};