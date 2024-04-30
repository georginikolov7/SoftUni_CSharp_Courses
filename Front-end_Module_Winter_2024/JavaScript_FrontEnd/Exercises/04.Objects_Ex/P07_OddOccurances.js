function solve(input) {
    let output = '';
    const wordsOccurances = input
        .toLowerCase()
        .split(' ')
        .reduce((result, word) => {
            if (!result[word]) {
                result[word] = 0;
            }
            result[word]++;
            return result;
        }, {});

    Object.entries(wordsOccurances)
        .filter(w => w[1] % 2 != 0)
        .forEach(w => output += w[0] + ' ');
    console.log(output);
}

solve('Java C# Php PHP Java PhP 3 C# 3 1 5 C#');