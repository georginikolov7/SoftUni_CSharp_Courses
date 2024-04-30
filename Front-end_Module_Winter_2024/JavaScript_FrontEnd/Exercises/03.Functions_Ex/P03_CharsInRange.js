function printCharsInRange(firstChar, secondChar) {
    let char1AsInt=firstChar.charCodeAt(0);
    let char2AsInt=secondChar.charCodeAt(0);
    let chars = [];
    let index = Math.min(char1AsInt, char2AsInt) + 1;
    let end = Math.max(char1AsInt, char2AsInt);

    for (let i = index; i < end; i++) {
        chars.push(String.fromCharCode(i));
    }
    
    console.log(chars.join(" "));
}
printCharsInRange('a','d');