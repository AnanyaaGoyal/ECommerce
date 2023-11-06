export class User {
    id!: number;
    firstName!: string;
    lastName!: string;
    username!: string;
    password!: string;
    gender! : string;
    birthDate!: Date;
    mobileNo!: string;
    role!: string;
    otp?:string;
    token?: string;
}