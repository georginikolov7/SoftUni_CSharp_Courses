function solve(words, templates) {
    let result = templates;
    let wordsArray = words.split(', ');
    for (let word of wordsArray) {
        let lengthToReplace = word.length;
        let regex = new RegExp(`[*]\{${lengthToReplace}\}`, 'i');
        result = result.replace(regex, word);
        ;
    }
    return result;


}
solve('great', 'softuni is ***** place for learning new programming languages');
solve('great, learning',
'softuni is ***** place for ******** new programming languages'
);