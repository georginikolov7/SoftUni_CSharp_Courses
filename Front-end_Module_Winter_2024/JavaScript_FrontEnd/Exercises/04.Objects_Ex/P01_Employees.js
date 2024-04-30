function solve(input) {
    const people = {};

    for (const name of input) {
        const personalNumber = name.length;
        people[name] = personalNumber;
    }

    for (const person in people) {
        console.log(`Name: ${person} -- Personal Number: ${people[person]}`);
    }
}
solve([
    'Silas Butler',
    'Adnaan Buckley',
    'Juan Peterson',
    'Brendan Villarreal'
    ]
    );