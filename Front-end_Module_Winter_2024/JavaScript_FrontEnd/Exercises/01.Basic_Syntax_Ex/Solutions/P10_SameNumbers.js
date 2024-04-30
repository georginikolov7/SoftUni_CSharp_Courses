function solve(number) {
    let temp = number;
    let lastDigit = temp % 10;
    let sum = lastDigit;
    let result=true;
    temp = Math.trunc(temp / 10);
    while (temp > 0) {
        let digit = temp % 10;
        if (digit != lastDigit) {
            result=false;
        }
        sum+=digit;
        temp=Math.trunc(temp/10);
    }
    console.log(result);
    console.log(sum);
}