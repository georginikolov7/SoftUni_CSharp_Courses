function attachEvents() {
    const url = 'http://localhost:3030/jsonstore/forecaster';

    const getWeatherButton = document.querySelector('input#submit[type=button]');
    const inputElement = document.querySelector('input#location[type=text]');

    const currentDiv = document.querySelector('div#forecast div#current');
    const upcomingDiv = document.querySelector('div#forecast div#upcoming');

    const symbolsMapper = {
        'Sunny': '☀',
        'Partly sunny': '⛅',
        'Overcast': '☁',
        'Rain': '☂',

    }
    getWeatherButton.addEventListener('click', e => {
        fetch(`${url}/locations`)
            .then(res => res.json())
            .then(data => {
                const { code } = data.find(location => location.name === inputElement.value);

                return Promise.all([fetch(`${url}/today/${code}`),
                fetch(`${url}/upcoming/${code}`)]);
            })
            .then(responses => Promise.all(responses.map(res => res.json())))
            .then(([today, upcoming]) => {
                const divContainer = document.createElement('div');
                divContainer.classList.add('forecasts');
                const symbolSpanElement = document.createElement('span');
                symbolSpanElement.classList.add('condition');
                symbolSpanElement.classList.add('symbol');
                symbolSpanElement.textContent = symbolsMapper[today.forecast.condition];
                divContainer.appendChild(symbolSpanElement);
                const anotherSpan = document.createElement('span');
                anotherSpan.innerHTML = `
                    <span class="forecast-data">${today.name}</span>
                    <span class="forecast-data">${today.forecast.low}°/${today.forecast.high}°</span>
                    <span class="forecast-data">${today.forecast.condition}</span>
                `;
                anotherSpan.classList.add('condition');
                divContainer.appendChild(anotherSpan);
                currentDiv.appendChild(divContainer);


                //Upcoming:
                function generateUpcomingSpanHTML(symbol, low, high, condition) {
                    return `
                    <span class="upcoming">
                    <span class="symbol">${symbol}</span>
                    <span class="forecast-data">${low}°/${high}°</span>
                    <span class="forecast-data">${condition}</span>
                </span>
                    `;
                }
                const upcomingDivContainer = document.createElement('div');
                upcomingDivContainer.classList.add('forecast-info');
                upcomingDivContainer.innerHTML = `
                ${generateUpcomingSpanHTML(
                    symbolsMapper[upcoming.forecast[0].condition],
                    upcoming.forecast[0].low,
                    upcoming.forecast[0].high,
                    upcoming.forecast[0].condition
                )}
                ${generateUpcomingSpanHTML(
                    symbolsMapper[upcoming.forecast[1].condition],
                    upcoming.forecast[1].low,
                    upcoming.forecast[1].high,
                    upcoming.forecast[1].condition
                )}
                ${generateUpcomingSpanHTML(
                    symbolsMapper[upcoming.forecast[2].condition],
                    upcoming.forecast[2].low,
                    upcoming.forecast[2].high,
                    upcoming.forecast[2].condition
                )}
                `;
                upcomingDiv.appendChild(upcomingDivContainer);
                currentDiv.parentElement.style.display = 'block';
            });
        // .catch(()=>)
    });
};


attachEvents();