import Circle from './1/class/Circle.js';
import Square from './1/class/Square.js';
import { Circle as protoCircle } from './1/prototype/Circle.js';
import { Square as protoSquare } from './1/prototype/Square.js';

console.log(new Circle(12).Area());
console.log(new Square(12).Area());

const pc = protoCircle;
const ps = protoSquare;
pc.constructor(12);
ps.constructor(12);
console.log(pc.Area());
console.log(ps.Area());