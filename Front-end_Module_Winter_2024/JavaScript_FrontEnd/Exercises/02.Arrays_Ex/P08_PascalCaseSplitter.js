function solve(pascalCaseText) {
    let pattern = /[A-Z][a-z]*/g;
    let words = Array
        .from(pascalCaseText.matchAll(pattern))
        .map(word => word[0]);

    let result = words.join(', ');
    console.log(result);
}
solve('SplitMeIfYouCanHaHaYouCantOrYouCan');