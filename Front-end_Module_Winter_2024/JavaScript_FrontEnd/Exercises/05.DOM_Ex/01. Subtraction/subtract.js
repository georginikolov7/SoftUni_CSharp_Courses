function subtract() {
    console.log('TODO:...');
    const n1 = Number(document.getElementById('firstNumber').value);
    const n2 = Number(document.getElementById('secondNumber').value);

    const resultElement = document.getElementById('result');
    resultElement.textContent = n1 - n2;
}