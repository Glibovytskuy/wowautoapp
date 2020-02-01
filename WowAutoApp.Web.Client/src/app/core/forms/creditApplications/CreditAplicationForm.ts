import { FormControl, FormGroup, Validators } from "@angular/forms";

export class CreditAplicationForm {
    public CreditAplicationForm: FormGroup = new FormGroup({
        FirstName: new FormControl('', [
            Validators.required,
            Validators.minLength(2),
            Validators.maxLength(64),
            Validators.pattern(/^(.*\S+.*)$/)
        ]),
        LastName: new FormControl('', [
            Validators.required,
            Validators.minLength(2),
            Validators.maxLength(64),
            Validators.pattern(/^(.*\S+.*)$/)]),
        SocialSecurityNumber: new FormControl('', [
            Validators.required,
            Validators.min(0),
            // Validators.pattern(/[0-9.+]/)
            // Validators.pattern(/^\d{3}-\(*[A-Za-z]{2}-\d{4}$/)
            Validators.pattern(/^\d{3}-\d{2}-\d{4}$/)

        ]),
        DateOfBirth: new FormControl('', [Validators.required]),
        PhoneNumber: new FormControl('', [
            // Validators.required,
            Validators.minLength(10),
            Validators.maxLength(15),
            Validators.pattern(/^\d+$/)]),
        Email: new FormControl('', [Validators.required, Validators.email]),
        StreetAddress: new FormControl('', [Validators.required]),
        City: new FormControl('', [Validators.required]),
        State: new FormControl('', [Validators.required]),
        ZipCode: new FormControl(null, [
            Validators.required,
            Validators.min(0),
            Validators.pattern(/[0-9+]/)
        ]),
        ResidenceOwner: new FormControl(null, [Validators.required]),
        MonthlyRent: new FormControl(null, [
            Validators.required,
            Validators.min(0),
            Validators.pattern(/[0-9+]/)
        ]),
        MobileNumber: new FormControl('', [
            Validators.required,
            Validators.minLength(10),
            Validators.maxLength(15),
            Validators.pattern(/^\d+$/)]),



        SecurityStamp: new FormControl(''),
        IsEmailVerified: new FormControl(false),
        HouseFlatNumber: new FormControl(null),
        VehicleName: new FormControl(''),
        EmploymentStatus: new FormControl(null, [Validators.required]),
        DownPayment: new FormControl(null),
        TotalAmount: new FormControl(null),
        OtherInfo: new FormControl(''),
        DriverLicensePhotoId: new FormControl(''),
        Password: new FormControl('', [
            Validators.required,
            Validators.minLength(6),
            Validators.maxLength(64),
            Validators.pattern(/^.*((?=.*[!@#$%^&*()\-_=+{};:,<.>]){1})(?=.*\d)((?=.*[a-z]){1})((?=.*[A-Z]){1}).*$/)
        ]),
        ConfirmPassword: new FormControl('', [
            Validators.required,
            Validators.minLength(6),
            Validators.maxLength(64),
            Validators.pattern(/^.*((?=.*[!@#$%^&*()\-_=+{};:,<.>]){1})(?=.*\d)((?=.*[a-z]){1})((?=.*[A-Z]){1}).*$/)
        ])
    });
}

// ^\d{3}-\(*[A-Za-z]{2}-\d{4}$