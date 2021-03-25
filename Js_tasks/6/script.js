let VowelsCount = (str) => Array.from(str.toLowerCase()).filter(letter => "aeiou".includes(letter)).length;

console.log(VowelsCount("zxcbzxvasfgdgwe"));
console.log(VowelsCount("aaucncvb"));
console.log(VowelsCount("qazxergiojnb"));