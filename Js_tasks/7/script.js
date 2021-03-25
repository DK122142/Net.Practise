let FirstOrLast = (array) => {
    if (array.length > 0) {
        if (array[0] == 1 || array[array.length - 1] == 1) {
            return true;
        } else {
            return false;
        }
    }
}

console.log(FirstOrLast([1, 4, 3, 7]));
console.log(FirstOrLast([3, 4, 3, 1]));
console.log(FirstOrLast([6, 4, 3, 7]));
console.log(FirstOrLast([1, 4, 3, 1]));