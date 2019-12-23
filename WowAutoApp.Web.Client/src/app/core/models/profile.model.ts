export interface Profile {
  FirstName: string;
  LastName: string;
  Email: string;
  IsEmailVerified: boolean;
  MobileNumber: string;
  PhoneNumber: string;
  DateOfBirth: Date;
  SocialSecurityNumber: number;
  StreetAddress: string;
  HouseFlatNumber: number;
  VehicleName: string;
  State: string;
  ZipCode: string;
  MonthlyRent: number;
  ResidenceOwner: string;
  EmploymentStatus: string;
  DownPayment: number;
  TotalAmount: number;
  OtherInfo: string;
  DriverLicensePhotoId: number;
  Password: string;
  ConfirmPassword: string;
  City: string;
  SecurityStamp: string;
  CallbackUrl: string;
}
