import { Shape } from './Shape.js';

export const Square = {
    __proto__: Shape,
    side: 0,
    constructor(side) {
        this.side = side;
    },
    Area() {
        return this.side ** 2;
    }
}