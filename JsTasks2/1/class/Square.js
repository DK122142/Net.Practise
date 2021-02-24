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

// console.log(new Square(12).Area());