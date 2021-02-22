let addRuBefore = (str) => {

    if (str == '' || str.startsWith("Ру")) {
        return str;
    }

    return "Ру" + str;
}

console.log(addRuBefore(""));
console.log(addRuBefore("cvcn"));
console.log(addRuBefore("Руdgdf"));