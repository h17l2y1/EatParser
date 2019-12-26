import { ProductView } from '../product/product-model.view';

export class SushiView {
    public sushi: SushiViewItem[];

    constructor() {
        this.sushi = new Array<SushiViewItem>();
    }
}

export class SushiViewItem implements ProductView {
    name: string;
    description: string;
    weight?: number;
    count?: number;
    price?: number;
    image: string;
    restaurantId: number;
}
