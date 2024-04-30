function solve(tokens) {
    const addressBook = {};
    for (const token of tokens) {
        const [name, adress] = token.split(':');
        addressBook[name] = adress;
    }

    Object
        .keys(addressBook)
        .sort((a, b) => a.localeCompare(b))
        .forEach(p => console.log(`${p} -> ${addressBook[p]}`));
}