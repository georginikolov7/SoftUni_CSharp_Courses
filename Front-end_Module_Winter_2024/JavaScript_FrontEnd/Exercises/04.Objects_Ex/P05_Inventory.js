function solve(input) {
    const heroes = [];
    for (const row of input) {
        const [name, level, itemsString] = row.split(' / ');
        heroes.push({
            name,
            level: Number(level),
            items: itemsString.split(', ')
        });
    }

    const sorted = heroes.sort((h1, h2) => h1.level-h2.level);
    for (const hero of sorted) {
        console.log(`Hero: ${hero.name}`);
        console.log(`level => ${hero.level}`);
        console.log(`items => ${hero.items.join(', ')}`);
    }
}
solve([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
    ]
    );