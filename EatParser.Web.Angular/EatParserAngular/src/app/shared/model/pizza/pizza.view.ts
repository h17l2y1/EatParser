import { ProductView } from '../product/product-model.view';

export class PizzaView {
    public pizzas: PizzaViewItem[];

    constructor() {
        this.pizzas = new Array<PizzaViewItem>();
    }
}

export class PizzaViewItem implements ProductView {
    name: string;
    description: string;
    weight?: number;
    count?: number;
    price?: number;
    image: string;
    restaurantId: string;
}
