let last = (array, count = 1) => {
    if (count > array.length) {
        count = array.length;
    }

    return array.slice((array.length - count), array.length);
}

console.log(last([7, 9, 0, -2]));
console.log(last([7, 9, 0, -2], 3));
console.log(last([7, 9, 0, -2], 6));