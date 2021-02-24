import Square from '../1/class/Square.js';

export const GetFieldsAndMethods = (obj) => {
    let properties = new Set()
    let currentObj = obj
    do {
        Object.getOwnPropertyNames(currentObj).map(item => properties.add(item))
    } while ((currentObj = Object.getPrototypeOf(currentObj)))
    return [...properties];
}

// console.log(GetFieldsAndMethods(new Square(12)));