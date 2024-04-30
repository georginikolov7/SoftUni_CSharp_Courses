function solve(inputString) {
    let pattern = /#[a-zA-Z]+/g;
    let matches = Array.from(inputString.matchAll(pattern));
    let specialWords = matches.map(word => word[0]);
    specialWords = specialWords.map(word => word.replace('#', ''));
    for (let word of specialWords) {
        console.log(word);
    }

}
solve('Nowadays everyone uses # to tag a #special word in #socialMedia');