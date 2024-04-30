function solve(input) {
    const towns = [];
    for (const row of input) {
        const [town, latitude, longitude] = row.split(" | ");
        towns.push({
            town: town,
            latitude: Number(latitude).toFixed(2),
            longitude: Number(longitude).toFixed(2)
        });
    }

    for (const entry of towns) {
        console.log(entry);
    }
}
solve(['Sofia | 42.696552 | 23.32601',
'Beijing | 39.913818 | 116.363625']
);