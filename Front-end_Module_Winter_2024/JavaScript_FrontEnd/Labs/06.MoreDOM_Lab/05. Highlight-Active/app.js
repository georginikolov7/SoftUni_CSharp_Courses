function focused() {
    console.log('TODO:...');
    const inputElements = document.querySelectorAll('input[type=text]');
    for (inputEl of inputElements) {
        inputEl.addEventListener('blur', event => {
            event.target.parentElement.classList.remove('focused');
        });
        inputEl.addEventListener('focus', event => {
            event.target.parentElement.classList.add('focused');
        });
    }
}