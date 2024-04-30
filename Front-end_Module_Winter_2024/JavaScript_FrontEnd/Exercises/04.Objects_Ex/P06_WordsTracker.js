function solve(input) {
    const dictionary = input
        .shift()
        .split(' ')
        .reduce((result, word) => {
            result[word] = 0;
            return result;
        }, {});

    for (const word of input) {
        if (dictionary.hasOwnProperty(word)) {
            dictionary[word]++;
        }
    }

    const sorted = Object
        .entries(dictionary)
        .sort((a, b) => b[1] - a[1])
        .forEach(([word, occurances]) => {
            console.log(`${word} - ${occurances}`);
        });

}
solve([
    'this sentence',
    'In', 'this', 'sentence', 'you', 'have', 'to', 'count', 'the', 'occurrences', 'of', 'the', 'words', 'this', 'and', 'sentence', 'because', 'this', 'is', 'your', 'task'
]
);