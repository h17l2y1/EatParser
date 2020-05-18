import { ProductView } from '../product/product-model.view';

export class RolsView {
    public rols: RolsViewItem[];

    constructor() {
        this.rols = new Array<RolsViewItem>();
    }
}

export class RolsViewItem implements ProductView {
    name: string;
    description: string;
    weight?: number;
    count?: number;
    price?: number;
    image: string;
    restaurantId: string;
}

