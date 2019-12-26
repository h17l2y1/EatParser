import { ProductView } from '../product/product-model.view';

export class SetsView {
    public sets: SetsViewItem[];

    constructor() {
        this.sets = new Array<SetsViewItem>();
    }
}

export class SetsViewItem implements ProductView {
    name: string;
    description: string;
    weight?: number;
    count?: number;
    price?: number;
    image: string;
    restaurantId: number;
}

