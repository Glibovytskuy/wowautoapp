export enum OwnerType {
    SelfOrSpouse = 0,
    Landlord  = 1,
    Relative = 2,
    Mortgage = 3,
    Others = 4
}

export namespace OwnerType {

    export function values() {
        return Object.keys(OwnerType).filter(
            (type) => isNaN(<any>type) && type !== 'values'
        );
    }
}   