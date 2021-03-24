let MaxMult = (array) => {
    let result = [];

    for (var i = 0; i <= array.length - 2; i = i + 2) {
        result.push(array[i] * array[i + 1]);
    };

    return Math.max(...result);
}

console.log(MaxMult([3, 6, -2, -5, 7, 3]));