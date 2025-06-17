import { Customer } from "./Customer";
import { Product } from "./Product";

export class CompletePurchase {
    constructor(public currentUser?: Customer, public purchaseAmount?: number,
        public note?: string, public products: Product[] = []) { }
}
