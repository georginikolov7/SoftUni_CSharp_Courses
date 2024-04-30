function solve(speed, area) {
    let status;
    let speedLimit;
    switch (area) {
        case 'motorway':
            speedLimit = 130;
            break;
        case 'interstate':
            speedLimit = 90;

            break;
        case 'city':
            speedLimit = 50;

            break;
        case 'residential':
            speedLimit = 20;

            break;
    }

    let speeding = false;
    let speedingSpeed;
    if (speed > speedLimit) {
        speeding = true;
        speedingSpeed = speed - speedLimit;
    }
    if (speeding) {
        if (speedingSpeed <= 20) {
            status = 'speeding';
        } else if (speedingSpeed <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }
        console.log(`The speed is ${speedingSpeed} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    } else {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    }
}