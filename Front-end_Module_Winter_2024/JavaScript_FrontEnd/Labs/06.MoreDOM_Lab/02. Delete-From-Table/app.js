function deleteByEmail() {
    console.log('TODO:...');
    const inputElement = document.querySelector('input[name=email]');
    const resultElement = document.getElementById('result');
    const tableRowElements = document.querySelectorAll('table#customers tbody tr');

    const trElement = Array
        .from(tableRowElements)
        .find(el => el.children[1].textContent.includes(inputElement.value));
    if (trElement) {
        trElement.remove();
        resultElement.textContent = 'Deleted';
    } else {
        resultElement.textContent = 'Not found.';
    }
    inputElement.value = '';
}