function solve(input) {
    function prepare(baristas, name, shift, coffeeType) {
        if (baristas[name].shift === shift && baristas[name].drinks.includes(coffeeType)) {
            console.log(`${name} has prepared a ${coffeeType} for you!`);
            return;
        }
        console.log(`${name} is not available to prepare a ${coffeeType}.`);
    }
    function changeShift(baristas, name, newShift) {
        baristas[name].shift = newShift;
        console.log(`${name} has updated his shift to: ${newShift}`);
    }
    function learn(baristas, name, newCoffeeType) {
        if (baristas[name].drinks.includes(newCoffeeType)) {
            console.log(`${name} knows how to make ${newCoffeeType}.`);
            return;
        }

        baristas[name].drinks.push(newCoffeeType);
        console.log(`${name} has learned a new coffee type: ${newCoffeeType}.`);
    }
    const baristas = {};
    const count = Number(input.shift());
    for (let i = 0; i < count; i++) {
        const [name, shift, coffeeList] = input.shift().split(" ");
        baristas[name] = {
            name,
            shift,
            drinks: Array.from(coffeeList.split(','))
        };
    }

    let currentRow = input.shift();
    while (!currentRow.includes('Closed')) {
        const [command, name, firstArg, secondArg] = currentRow.split(' / ');

        switch (command) {
            case 'Prepare':
                prepare(baristas, name, firstArg, secondArg);
                break;
            case 'Change Shift':
                changeShift(baristas, name, firstArg);
                break;
            case 'Learn':
                learn(baristas, name, firstArg);
                break;
        }
        currentRow = input.shift();
    }

    for (const barista in baristas) {
        console.log(`Barista: ${barista}, Shift: ${baristas[barista].shift}, Drinks: ${baristas[barista].drinks.join(', ')}`);
    }

}
solve([
    '3',
    'Alice day Espresso,Cappuccino',
    'Bob night Latte,Mocha',
    'Carol day Americano,Mocha',
    'Prepare / Alice / day / Espresso',
    'Change Shift / Bob / night',
    'Learn / Carol / Latte',
    'Learn / Bob / Latte',
    'Prepare / Bob / night / Latte',
    'Closed']
);