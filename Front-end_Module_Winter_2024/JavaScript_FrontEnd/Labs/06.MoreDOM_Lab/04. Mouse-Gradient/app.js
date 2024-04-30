function attachGradientEvents() {
    console.log('TODO:...');
    const gradientElement = document.getElementById('gradient');
    const resultElement = document.getElementById('result');
    // const xLength=gradientElement.
    gradientElement.addEventListener('mousemove', (event) => {
        //   console.log(event);
        const width = gradientElement.clientWidth-1;
        const currentOffset = event.offsetX;

        const result = Math.trunc(currentOffset / width * 100);
        resultElement.textContent = result + '%';
    })
}