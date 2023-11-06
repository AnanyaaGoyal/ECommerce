import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { AccountService } from "../core/_services/account.service";
import { Router } from "@angular/router";
import { first } from "rxjs";
import { ToastrService } from "ngx-toastr";

@Component({
    selector: 'app-register',
    templateUrl: 'register.component.html'
})

export class RegisterComponent implements OnInit {
    form!: FormGroup;
    submitted = false;

    constructor(private formBuilder: FormBuilder,
        private accountService: AccountService,
        private router: Router,
        private toastr: ToastrService) { };

    pattern1 = "^[0-9_-]{10,10}";

    ngOnInit() {
        this.form = this.formBuilder.group({
            firstName: ['', Validators.required],
            lastName: [''],
            username: ['', Validators.required],
            password: ['', [Validators.required, Validators.minLength(6)]],
            gender: ['', Validators.required],
            birthDate: ['', Validators.required],
            mobileNo: ['', [Validators.pattern(this.pattern1)]],
            role: ['', Validators.required]
        });
    }

    get f() {
        return this.form.controls;
    }

    onSubmit() {
        this.submitted = true;
        if (this.form.invalid)
            return;

        this.accountService.register(this.form.value)
            .pipe(first())
            .subscribe({
                next: (response) => {
                    if (response.statusCode == 200) {
                        this.router.navigate(['']);
                        this.toastr.success(response.message);
                    }
                    else {
                        this.toastr.error(response.message);
                    }
                },
                error: (error) => {
                    console.log(error);
                }
            })
    }
};