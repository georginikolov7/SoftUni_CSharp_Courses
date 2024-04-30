function solve(n1, n2) {
    function calculateFactorial(number) {
        if (number <= 1) {
            return 1;
        }
        return number * calculateFactorial(number - 1);
    }

    console.log((calculateFactorial(n1) / calculateFactorial(n2)).toFixed(2));
}
solve(5, 2);