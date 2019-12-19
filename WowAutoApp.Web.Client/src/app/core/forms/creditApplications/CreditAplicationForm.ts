import { FormControl, FormGroup, Validators } from "@angular/forms";

export class CreditAplicationForm {
    public CreditAplicationForm: FormGroup = new FormGroup({
        City: new FormControl(''),
        SecurityStamp: new FormControl(''),
        CallbackUrl: new FormControl(''),
        FirstName: new FormControl(''),
        LastName: new FormControl(''),
        Email: new FormControl(''),
        IsEmailVerified: new FormControl(''),
        MobileNumber: new FormControl(''),
        PhoneNumber: new FormControl(''),
        DateOfBirth: new FormControl(''),
        SocialSecurityNumber: new FormControl(''),
        StreetAddress: new FormControl(''),
        HouseFlatNumber: new FormControl(''),
        City1: new FormControl(''),
        State: new FormControl(''),
        ZipCode: new FormControl(''),
        MonthlyRent: new FormControl(''),
        ResidenceOwner: new FormControl(''),
        EmploymentStatus: new FormControl(''),
        DownPayment: new FormControl(''),
        TotalAmount: new FormControl(''),
        OtherInfo: new FormControl('']),
        DriverLicensePhotoId: new FormControl(''),
        Password: new FormControl(''),
        ConfirmPassword: new FormControl('')
    });
}