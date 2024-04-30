
function findPalindromes(numbers) {
    function convertNumberToDigitsArray(number) {
        let temp = number;
        let arr = [];
        while (temp > 0) {
            let digit = temp % 10;
            arr.unshift(digit); //add digit to beginning of array
            temp = Math.floor(temp / 10);
        }
        return arr;
    }

    for (let number of numbers) {
        let digits = convertNumberToDigitsArray(number);
        let isPalindrome = true;
        let length = digits.length;
        for (let i = 0; i < length; i++) {
            if (digits[i] != digits[length - i - 1]) {
                isPalindrome = false;
                break;
            }
        }
        console.log(isPalindrome);
    }
}
findPalindromes([123, 323, 421, 121]);