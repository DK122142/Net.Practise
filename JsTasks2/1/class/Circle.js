import Shape from './Shape.js';

class Circle extends Shape {
    constructor(radius) {
        super();
        this.radius = radius;
    }

    Area() {
        return Math.PI * this.radius ** 2;
    }
}

// console.log(new Circle(12).Area());