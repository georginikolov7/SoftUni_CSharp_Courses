function printAndSum(start, end) {
    let sum = 0;
    let resultString='';
    for (let i = start; i <= end; i++) {
        resultString += i + ' ';
        sum += i;
    }
    console.log(resultString.trim());
    console.log(`Sum: ${sum}`);
}