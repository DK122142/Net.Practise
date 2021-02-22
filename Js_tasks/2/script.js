(function() {
    for (let index = 2014; index < 2050; index++) {

        let element = new Date(index, 0, 1);

        if (element.getDay() == 0) {
            console.log(element.getFullYear());
        }
    }
})();