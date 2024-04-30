function solve(city) {

    // let city = {
    //     name: name,
    //     area: area,
    //     population: population,
    //     country: country,
    //     postCode: postcode
    // };

    Object
        .keys(city)
        .forEach(propName => console.log(`${propName} -> ${city[propName]}`));
}