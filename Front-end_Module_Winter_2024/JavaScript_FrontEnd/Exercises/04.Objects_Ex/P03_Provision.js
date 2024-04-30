function solve(stockArray, orderedArray) {

    function addToStock(stockArray, stockToAdd) {
        for (let i = 0; i < stockToAdd.length - 1; i += 2) {
            const stock = stockToAdd[i];
            const quantity = Number(stockToAdd[i + 1]);

            if (!stockArray[stock]) {
                stockArray[stock] = 0;
            }
            stockArray[stock] += quantity;
        }
        return stockArray;
    }
    let currentStock = {};
    currentStock = addToStock(currentStock, stockArray);
    currentStock = addToStock(currentStock, orderedArray);


    for (const stock in currentStock) {
        console.log(`${stock} -> ${currentStock[stock]}`);
    }
}

solve([
    'Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'
],
    [
        'Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'
    ]
);