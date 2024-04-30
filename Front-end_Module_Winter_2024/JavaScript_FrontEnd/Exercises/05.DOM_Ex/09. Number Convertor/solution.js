function solve() {

    //TODO...
    const inputNumElement = document.getElementById('input');
    const selectMenuFromElement = document.getElementById('selectMenuFrom');
    const selectMenuToElement = document.getElementById('selectMenuTo');
    const convertButtonElement = document.querySelector('button');

    //Populate selectMenuTo with options:
    const binaryOptionElement = selectMenuToElement.querySelector('option');
    binaryOptionElement.value = "binary";
    binaryOptionElement.textContent = "Binary";

    const hexOptionElement = document.createElement('option');
    hexOptionElement.value = "hexadecimal";
    hexOptionElement.textContent = "Hexadecimal";
    selectMenuToElement.appendChild(hexOptionElement);

    const convertors = {
        'binary': convertToBinary,
        'hexadecimal': convertToHex,
    };

    const resultElement = document.getElementById('result');
    convertButtonElement.addEventListener('click', () =>
        resultElement.value = convertors[selectMenuToElement.value](Number(inputNumElement.value)));

    function convertToBinary(num) {
        let result = [];
        while (num > 0) {
            result.push(num % 2);
            num = Math.trunc(num / 2);
        }
        return result.reverse().join('');
    }
    function convertToHex(num) {
        const digitMapping = new Map([
            [0, '0'],
            [1, '1'],
            [2, '2'],
            [3, '3'],
            [4, '4'],
            [5, '5'],
            [6, '6'],
            [7, '7'],
            [8, '8'],
            [9, '9'],
            [10, 'A'],
            [11, 'B'],
            [12, 'C'],
            [13, 'D'],
            [14, 'E'],
            [15, 'F'],
        ]);
        let result = [];
        while (num > 0) {
            result.push(digitMapping.get(num % 16));
            num = Math.trunc(num / 16);
        }
        return result.reverse().join('');
    }
}