function attachEventsListeners() {
    console.log('TODO:...');

    const convertersToMeters = {
        'km': (km) => km * 1000,
        'm': (m) => m,
        'cm': cm => cm / 100,
        'mm': mm => mm / 1000,
        'mi': M => M * 1609.34,
        'yrd': y => y * 0.9144,
        'ft': f => f * 0.3048,
        'in': i => i * 0.0254,
    };
    const convertersFromMeters = {
        'km': (m) => m / 1000,
        'm': (m) => m,
        'cm': m => m * 100,
        'mm': m => m * 1000,
        'mi': m => m / 1609.34,
        'yrd': m => m / 0.9144,
        'ft': m => m / 0.3048,
        'in': m => m / 0.0254,
    };

    const inputValueElement = document.querySelector('#inputDistance');
    const outputElement = document.querySelector('#outputDistance');

    const buttonElement = document.querySelector('#convert');

    const inputSelectElement = document.querySelector('#inputUnits');
    const outputSelectElement = document.querySelector('#outputUnits');

    buttonElement.addEventListener('click', () => {
        const selectedUnit = inputSelectElement.options[inputSelectElement.selectedIndex].value;
        const outputUnit = outputSelectElement.options[outputSelectElement.selectedIndex].value;
        console.log(selectedUnit);
        console.log(outputUnit);
        const input = inputValueElement.value;
        outputElement.value = convertersFromMeters[outputUnit](convertersToMeters[selectedUnit](input));
    });
}