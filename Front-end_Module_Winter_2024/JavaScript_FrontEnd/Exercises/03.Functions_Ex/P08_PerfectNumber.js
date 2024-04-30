function checkNumberPerfectness(number) {
    const isPositiveInteger = n => Number.isInteger(n) && n > 0;
    function getSumOfProperDivisors(number) {
        let sum = 0;
        for (let i = 1; i < number; i++) {
            if (number % i == 0) {
                sum += i;
            }
        }
        return sum;
    }

    if (isPositiveInteger(number) && getSumOfProperDivisors(number) == number) {
        console.log('We have a perfect number!');
        return;
    }

    console.log('It\'s not so perfect.');
}