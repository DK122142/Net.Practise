import { Shape } from './Shape.js';

export const Circle = {
    __proto__: Shape,
    radius: 0,
    constructor(radius) {
        this.radius = radius;
    },
    Area() {
        return Math.PI * this.radius ** 2;
    }
}