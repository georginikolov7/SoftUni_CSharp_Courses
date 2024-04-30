function printMatrix(n) {
    for (let row = 0; row < n; row++) {
        let currentRow = [];
        for (let col = 0; col < n; col++) {
            currentRow.push(n);
        }
        console.log(currentRow.join(" "));
    }
}
printMatrix(7);