function solve(jsonString) {
    let obj = JSON.parse(jsonString);
    Object.keys(obj)
        .forEach(k => console.log(`${k}: ${obj[k]}`));
}