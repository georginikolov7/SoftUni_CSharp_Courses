function solve(text, word) {
    let occurances = 0;
    let index = 0;
    let words = text.split(' ');
    for (let cword of words) {
        if (cword === word) {
            occurances++;
        }
    }
    console.log(occurances);
}
solve('This is a word and it also is a sentence',
    'is'
);