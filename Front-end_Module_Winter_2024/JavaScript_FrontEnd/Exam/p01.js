function solve(input) {
    const count = Number(input.shift());

    //Assemble team:
    const heroes = {};
    for (let i = 0; i < count; i++) {
        const [name, hp, ammo] = input.shift().split(' ');
        heroes[name] = { name, hp, ammo };
    }

    let row = input.shift();
    while (row != 'Ride Off Into Sunset') {
        const [command, heroName, arg1, arg2] = row.split(' - ');
        const hero = heroes[heroName];
        switch (command) {
            case 'FireShot':
                if (hero.ammo < 1) {
                    console.log(`${heroName} doesn't have enough bullets to shoot at ${arg1}!`);
                    break;
                }
                hero.ammo -= 1;
                console.log(`${heroName} has successfully hit ${arg1} and now has ${hero.ammo} bullets!`);
                break;
            case 'TakeHit':
                hero.hp -= arg1;
                if (hero.hp > 0) {
                    console.log(`${heroName} took a hit for ${arg1} HP from ${arg2} and now has ${hero.hp} HP!`);
                    break;
                }
                delete heroes[heroName];
                console.log(`${heroName} was gunned down by ${arg2}!`);
                break;
            case 'Reload':
                if (hero.ammo == 6) {
                    console.log(`${heroName}'s pistol is fully loaded!`);
                    break;
                }
                console.log(`${heroName} reloaded ${6 - hero.ammo} bullets!`);
                hero.ammo = 6;
                break;
            case 'PatchUp':
                if (hero.hp == 100) {
                    console.log(`${heroName} is in full health!`);
                    break;
                }
                const initialValue = hero.hp;
                hero.hp = Math.min(100, initialValue + Number(arg1));
                console.log(`${heroName} patched up and recovered ${initialValue} HP!`);
                break;
        }
        row = input.shift();
    }

    //Print end result:
    for (const hero in heroes) {
        console.log(`${hero}\n HP: ${heroes[hero].hp}\n Bullets: ${heroes[hero].ammo}`);
    }
}
solve((["2",
    "Gus 100 0",
    "Walt 100 6",
    "TakeHit - Gus - 80 - Bandit",
    "PatchUp - Gus - 20",

    "Ride Off Into Sunset"])
);