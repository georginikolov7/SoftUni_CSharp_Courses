function reverse(n, arr) {
    let reversedArr = [];
    let length = arr.length;
    for (let i = 0; i < n; i++) {
        reversedArr[n - 1 - i] = arr[i];

    }
    let output = '';
    for (let i = 0; i < n; i++) {
        output += reversedArr[i];
        output += ' ';
    }
    console.log(output);
}
reverse(3, [10, 20, 30, 40, 50]);