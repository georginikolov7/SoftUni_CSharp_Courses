function toggle() {
    console.log('TODO:...');
    const btnElement = document.getElementsByClassName('button')[0];
    const textElement = document.getElementById('extra');
    if (btnElement.textContent === 'More') {
        textElement.style.display = 'block';
        btnElement.textContent = 'Less'

    } else if (btnElement.textContent === 'Less') {
        textElement.style.display = 'none';
        btnElement.textContent = 'More'
    }
}