export interface IProduct{
    name: string;
    productCode: string;
    brand: IBrand;
    type: IType;
    price: any;
}

export interface IBrand{
    name: string;
}

export interface IType{
    name: string;
}