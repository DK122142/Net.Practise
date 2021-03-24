import Shape from './Shape.js';

export default class Circle extends Shape {
    constructor(radius) {
        super();
        this.radius = radius;
    }

    Area() {
        return Math.PI * this.radius ** 2;
    }
}