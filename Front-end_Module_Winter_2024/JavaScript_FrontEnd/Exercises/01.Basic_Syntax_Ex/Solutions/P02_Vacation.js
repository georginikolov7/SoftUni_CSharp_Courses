function solve(groupCount, type, dayOfWeek) {
    let singlePrice;
    switch (type) {
        case "Students":
            if (dayOfWeek == "Friday") {
                singlePrice = 8.45;
            } else if (dayOfWeek == "Saturday") {
                singlePrice = 9.80;
            } else if (dayOfWeek == "Sunday") {
                singlePrice = 10.46;
            }
            if (groupCount >= 30) {
                singlePrice = 0.85 * singlePrice;
            }
            break;
        case "Business":
            if (dayOfWeek == "Friday") {
                singlePrice = 10.90;
            } else if (dayOfWeek == "Saturday") {
                singlePrice = 15.60;
            } else if (dayOfWeek == "Sunday") {
                singlePrice = 16;
            }
            if (groupCount >= 100) {
                groupCount -= 10;
            }
            break;
        case "Regular":
            if (dayOfWeek == "Friday") {
                singlePrice = 15;
            } else if (dayOfWeek == "Saturday") {
                singlePrice = 20;
            } else if (dayOfWeek == "Sunday") {
                singlePrice = 22.50;
            }
            if (groupCount >= 10 && groupCount <= 20) {
                singlePrice = 0.95 * singlePrice;
            }
            break;
    }
    let totalPrice = singlePrice * groupCount;
    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}