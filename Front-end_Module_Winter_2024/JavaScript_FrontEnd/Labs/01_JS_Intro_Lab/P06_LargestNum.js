function maxOfThree(num1, num2, num3) {
    let result;
    if (num1 > num2) {
        result = num1;
    } else {
        result = num2;
    }
    if (num3 > num1) {
        result = num3;
    }
    console.log(`The largest number is ${result}.`)
}