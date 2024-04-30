function addItem() {
    console.log('TODO:...');
    const inputTextElement = document.getElementById('newItemText');
    const liElement = document.createElement('li');
    liElement.textContent = inputTextElement.value;

    const listElement = document.querySelector('ul#items');
    listElement.appendChild(liElement);
    inputTextElement.value='';
}