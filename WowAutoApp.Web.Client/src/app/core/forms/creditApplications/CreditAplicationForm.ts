import { FormControl, FormGroup, Validators } from "@angular/forms";

export class CreditAplicationForm {
    public CreditAplicationForm: FormGroup = new FormGroup({
        City: new FormControl('', [Validators.required]),
        SecurityStamp: new FormControl(''),
        CallbackUrl: new FormControl(''),
        FirstName: new FormControl('', [Validators.required]),
        LastName: new FormControl('', [Validators.required]),
        Email: new FormControl('', [Validators.email]),
        IsEmailVerified: new FormControl(false),
        MobileNumber: new FormControl('', [Validators.required]),
        PhoneNumber: new FormControl(''),
        DateOfBirth: new FormControl(null, [Validators.required]),
        SocialSecurityNumber: new FormControl(0, [Validators.required]),
        StreetAddress: new FormControl('', [Validators.required]),
        HouseFlatNumber: new FormControl(0, [Validators.required]),
        VehicleName: new FormControl('', [Validators.required]),
        State: new FormControl('', [Validators.required]),
        ZipCode: new FormControl(''),
        MonthlyRent: new FormControl(0, [Validators.required]),
        ResidenceOwner: new FormControl(),
        EmploymentStatus: new FormControl(),
        DownPayment: new FormControl(0, [Validators.required]),
        TotalAmount: new FormControl(0, [Validators.required]),
        OtherInfo: new FormControl(''),
        DriverLicensePhotoId: new FormControl(''),
        Password: new FormControl('', [Validators.required]),
        ConfirmPassword: new FormControl('', [Validators.required])
    });
}