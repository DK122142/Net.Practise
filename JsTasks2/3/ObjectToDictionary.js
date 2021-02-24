import Square from '../1/class/Square.js';
import { GetFieldsAndMethods } from '../2/ShowFieldsAndMethods.js';

export const ObjToDict = (obj) => {
    let result = [];

    for (let key of GetFieldsAndMethods(obj)) {
        result.push([key, obj[key]]);
    }

    return result;
    // return Object.entries(obj);
}

// console.log(ObjToDict(new Square(12)));