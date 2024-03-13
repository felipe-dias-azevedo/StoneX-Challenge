export type ProductViewModel = {
  productName: string;
  stockKeepingUnit: string;
  price: number;
  stockCount: number;
};

export type ProductModel = {
    id: string;
    name: string;
    stockKeepingUnit: string;
    price: number;
    stockCount: number;
    insertDateTime: Date;
    updateDateTime: Date;
}
