import { FormControl, FormGroup, Validators } from "@angular/forms";

export class ShortRegisterForm {
    public ShortRegisterForm: FormGroup = new FormGroup({
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
        ]),
        SecurityStamp: new FormControl(''),
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
        Email: new FormControl('', [Validators.required, Validators.email]),
        ZipCode: new FormControl(null, [
            Validators.required,
            Validators.min(0),
            Validators.pattern(/[0-9+]/)
        ]),
    });
}