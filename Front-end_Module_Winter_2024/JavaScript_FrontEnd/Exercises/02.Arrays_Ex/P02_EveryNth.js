function hehe(array, n) {
    let output = [];
    for (let i = 0; i < array.length; i += n) {
        output.push(array[i]);
    }
    return output;
}
hehe(['5',
    '20',
    '31',
    '4',
    '20'],
    2
);