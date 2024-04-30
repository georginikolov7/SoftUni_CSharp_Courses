function solve(word, text) {
    let pattern = new RegExp(`\\b${word}\\b`, 'i');
    let match = text.match(pattern);
    if (match == null) {
        console.log(`${word} not found!`);
    } else {
        console.log(word);
    }
}
solve('JavaScript', 'JavaScript is the best programming language.');