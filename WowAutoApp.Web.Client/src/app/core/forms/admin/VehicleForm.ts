import { FormGroup, FormControl, Validators } from "@angular/forms";

export class VehicleForm {
    public VehicleForm: FormGroup = new FormGroup({
        FirstName: new FormControl(null, [
            Validators.required,
            Validators.minLength(2),
            Validators.maxLength(64),
            Validators.pattern(/^(.*\S+.*)$/)
        ]),
        LastName: new FormControl('', [
            Validators.required,
            Validators.minLength(2),
            Validators.maxLength(64),
            Validators.pattern(/^(.*\S+.*)$/)
        ]),
        MailingAddress: new FormControl('', [
            Validators.required,
            Validators.min(0)
        ]),
        Budget: new FormControl(null, [
            Validators.required,
            Validators.min(0),
            Validators.pattern(/[0-9+]/)
        ]),
        VehicleMake: new FormControl('', [Validators.required]),
        VehicleModel: new FormControl('', [Validators.required]),
        VehikleOld: new FormControl(null, [
            Validators.required,
            Validators.min(0),
            Validators.pattern(/[0-9+]/)
        ]),
        Description: new FormControl('', [Validators.required])
    });
}