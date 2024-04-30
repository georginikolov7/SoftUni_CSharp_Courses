function solve(input) {
    const appointments = {};
    for (const tokens of input) {
        const [day, person] = tokens.split(' ');
        if (appointments[day]) {
            console.log(`Conflict on ${day}!`);
        } else {
            appointments[day] = person;
            console.log(`Scheduled for ${day}`);
        }
    }

    for(const key in appointments){
        console.log(`${key} -> ${appointments[key]}`)
    }
}