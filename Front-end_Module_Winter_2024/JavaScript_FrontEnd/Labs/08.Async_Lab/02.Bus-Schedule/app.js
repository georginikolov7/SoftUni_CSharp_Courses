function solve() {

    const infoSpanElement = document.querySelector('.info');
    const departButtonElement = document.querySelector('input#depart');
    const arriveButtonElement = document.querySelector('input#arrive');

    let currentStopId = 'depot';
    let stopName;
    const url = 'http://localhost:3030/jsonstore/bus/schedule';

    function depart() {
        // TODO:
        departButtonElement.disabled = true;

        fetch(`${url}/${currentStopId}`)
            .then(res => res.json())
            .then(data => {
                const nextStopId = data.next;
                fetch(`${url}/${currentStopId}`)
                    .then(res1 => res1.json())
                    .then(data1 => {
                        stopName = data1.name;
                        console.log(data1);
                        infoSpanElement.textContent = `Next stop ${stopName}`;
                    })
                    .catch(err1 => console.log(err1));
                currentStopId = nextStopId;
                arriveButtonElement.disabled = false;
            })
            .catch(err => console.log(err));

    }

    async function arrive() {
        // TODO:
        arriveButtonElement.disabled = true;
        departButtonElement.disabled = false;
        infoSpanElement.textContent = `Arriving at ${stopName}`;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();