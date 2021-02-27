const lowerLimit = 1;
const upperLimit = 20;
const answer = Math.floor(Math.random() * (upperLimit - lowerLimit + 1)) + lowerLimit;
let guess = '';

console.log(answer);

while (guess != answer) {
    guess = prompt("Input guess between " + lowerLimit + " and " + upperLimit, guess);

    if (guess == null) {
        alert('Finish');
        break;
    } else if (isFinite(guess) && guess != '') {
        guess = +guess;

        if (guess < lowerLimit) {
            alert('Minimal number is ' + lowerLimit);
        } else if (guess > upperLimit) {
            alert('Maximum number is ' + upperLimit);
        } else if (answer < guess) {
            alert('Answer lower than your guess');
        } else if (answer > guess) {
            alert('Answer greater than your guess');
        } else {
            alert('Your guess right. Answer: ' + answer);
            break;
        }
    } else {
        alert('Invalid input');
    }
}