function solve(tokens) {
    const phoneBook = {};
    for (const token of tokens) {
        const [name, phone] = token.split(' ');
        phoneBook[name] = phone;
    }

    Object
        .keys(phoneBook)
        .forEach(p => console.log(`${p} -> ${phoneBook[p]}`));
}