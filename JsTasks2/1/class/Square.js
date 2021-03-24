import Shape from './Shape.js';

export default class Square extends Shape {
    constructor(side) {
        super();
        this.side = side;
    }

    Area() {
        return this.side ** 2;
    }
}