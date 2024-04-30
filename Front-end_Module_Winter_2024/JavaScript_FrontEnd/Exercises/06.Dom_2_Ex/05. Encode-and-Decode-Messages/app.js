function encodeAndDecodeMessages() {
    const sendButtonElement = document.querySelector('#main > div:first-child button');
    const receiveButtonElement = document.querySelector('#main > div:last-child button');
    console.log(sendButtonElement);
    console.log(receiveButtonElement);
    const inputTextareaElement = document.querySelector('#main > div:first-child textarea');
    const outputTextareaElement = document.querySelector('#main > div:last-child textarea');

    //Events:
    sendButtonElement.addEventListener('click', () => {
        let message = inputTextareaElement.value;
        inputTextareaElement.value = '';
        let encodedMessage = '';
        for (let ch of message) {
            encodedMessage += String.fromCharCode(ch.charCodeAt(0) + 1);
        }
        outputTextareaElement.value = encodedMessage;

    });
    receiveButtonElement.addEventListener('click', () => {
        let originalMessage = '';
        for (let ch of outputTextareaElement.value) {
            originalMessage += String.fromCharCode(ch.charCodeAt(0) - 1);
        }
        outputTextareaElement.value = originalMessage;
    })
};