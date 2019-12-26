export enum EmploymentStatusType {
    SelfEmployed = 0,
    Contract  = 1,
    Retired = 2,
    Unemployed = 3,
    BusinessOwner = 4
}

export namespace EmploymentStatusType {

    export function values() {
        return Object.keys(EmploymentStatusType).filter(
            (type) => isNaN(<any>type) && type !== 'values'
        );
    }
}   