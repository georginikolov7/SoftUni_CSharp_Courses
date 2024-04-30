function getCircleArea(input) {
    let type = typeof (input);
    if (type === 'number') {
        let area = Math.PI * input ** 2;
        console.log(area.toFixed(2));
        return;
    }
    console.log(`We can not calculate the circle area, because we receive a ${type}.`);
}
getCircleArea(5);