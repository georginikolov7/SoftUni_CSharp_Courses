function calculateOrder(item, quantity) {
    let totalPrice;
    switch (item) {
        case "coffee":
            totalPrice = quantity * 1.50;
            break;
        case "water":
            totalPrice = quantity * 1;
            break;
        case "coke":
            totalPrice = quantity * 1.40;
            break;
        case "snacks":
            totalPrice = quantity * 2;
            break;
    }
    console.log(totalPrice.toFixed(2));
}