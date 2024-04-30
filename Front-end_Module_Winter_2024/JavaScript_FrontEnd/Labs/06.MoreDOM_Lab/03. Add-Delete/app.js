function addItem() {
    //TODO...
    const inputElement = document.getElementById('newItemText');
    const itemsListElement = document.getElementById('items');

    const newItemElement = document.createElement('li');
    newItemElement.textContent = inputElement.value;

    //Append to list:
    itemsListElement.appendChild(newItemElement);

    //clear input:
    inputElement.value = '';

    //Add delete link:
    const deleteLinkElement = document.createElement('a');
    deleteLinkElement.textContent = '[Delete]';
    deleteLinkElement.href = '#';
    newItemElement.appendChild(deleteLinkElement);

    //Add event to delete element:
    deleteLinkElement.addEventListener('click', () => {
        newItemElement.remove();
    });
}