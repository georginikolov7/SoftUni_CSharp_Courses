function solve(firstName, lastName, hairColor) {
    const obj = {
        name: firstName,
        lastName,
        hairColor
    };
    const json = JSON.stringify(obj);
    console.log(json);
}