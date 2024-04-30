// function printOddEvenSums(number) {
//     let temp = number;
//     let oddSum = 0;
//     let evenSum = 0;

//     while (temp > 0) {
//         let digit = temp % 10;
//         if (digit % 2 == 0) {
//             evenSum += digit;
//         } else {
//             oddSum += digit;
//         }
//         temp = Math.floor(temp / 10);
//     }
//     console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
// }

function solve(number) {
    function getDigitsSum(number, filter) {
        const digits = number
            .toString()
            .split("")
            .map(Number)
            .filter(filter);
        return digits.reduce((acc, digit) => acc + digit, 0);
    }

    let oddSum=getDigitsSum(number,n=>n%2!=0);
    let evenSum=getDigitsSum(number,n=>n%2==0);
    console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}
solve(1000435);