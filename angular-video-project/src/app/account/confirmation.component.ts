import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { User } from "@app/core/_models";
import { AccountService } from "@app/core/_services/account.service";
import { ToastrService } from "ngx-toastr";

@Component({
    selector: 'app-confirmation',
    templateUrl: 'confirmation.component.html',
})

export class ConfirmationComponent implements OnInit {
    storedUser!: User;
    constructor(private accountService: AccountService,
        private router: Router,
        private toastr: ToastrService,
        private route: ActivatedRoute) {

    }

    ngOnInit(): void {
        const encryptedUser = this.route.snapshot.params['key'];
        const user = JSON.parse(atob(encryptedUser));
        this.storedUser = {
            id: user.Id,
            firstName: user.FirstName,
            lastName: user.LastName,
            username: user.Username,
            password: user.Password,
            gender: user.Gender,
            birthDate: user.BirthDate,
            mobileNo: user.MobileNo,
            role: user.Role,
            otp: user.Otp
        }
    }

    getOtp(otp: any) {
        if (otp.currentVal == this.storedUser.otp) {
            this.accountService.addUser(this.storedUser).subscribe({
                next: (result) => {
                    if (result.statusCode == 200) {
                        this.router.navigate(['']);
                        this.toastr.success(result.message);
                    }
                    else {
                        this.router.navigate(['/register']);
                        this.toastr.error(result.message);
                    }
                },
                error: (error) => {
                    console.log(error);
                    this.router.navigate(['/register']);
                }
            });
        }
        else {
            this.toastr.error("Otp does not match");
        }
    }
}