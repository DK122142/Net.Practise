const weekDays = [
    "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
];

const options = { weekday: 'long' };

(function() {
    for (let index = 2014; index < 2050; index++) {

        let element = new Date(index, 0, 1);

        // if (new Intl.DateTimeFormat('en-US', options).format(element) === weekDays[0]) {
        //     console.log(element.getFullYear());
        // }

        if (element.getDay() === weekDays.indexOf("Sunday")) {
            console.log(element.getFullYear());
        }
    }
})();