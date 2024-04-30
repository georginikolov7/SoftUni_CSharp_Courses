function addItem() {
    const dropdownElement = document.getElementById('menu');
    const inputTextElement = document.querySelector('input[type=text][id=newItemText]');
    const inputValueElement = document.querySelector('input[type=text][id=newItemValue]');

    const optionElement = document.createElement('option');
    optionElement.textContent = inputTextElement.value;
    optionElement.value = inputValueElement.value;
    dropdownElement.appendChild(optionElement);

    inputTextElement.value = '';
    inputValueElement.value = '';
}