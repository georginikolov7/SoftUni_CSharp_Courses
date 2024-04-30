function solve(input) {
    const parkingSet = new Set();
    for (const entry of input) {
        const [cmd, registration] = entry.split(', ');
        switch (cmd) {
            case 'IN':
                parkingSet.add(registration);
                break;
            case 'OUT':
                parkingSet.delete(registration);
                break;
        }
    }
    if (parkingSet.size < 1) {
        console.log('Parking Lot is Empty');
        return;
    }
    Array.from(parkingSet.values())
        .sort((a, b) => a.localeCompare(b))
        .forEach(reg => console.log(reg));
}