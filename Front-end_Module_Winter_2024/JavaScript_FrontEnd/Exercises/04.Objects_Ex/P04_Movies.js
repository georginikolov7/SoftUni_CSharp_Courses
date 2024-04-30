function solve(input) {
    const addCmd = 'addMovie';
    const directedByCmd = 'directedBy';
    const onDateCmd = 'onDate';

    const movies = [];
    for (const command of input) {
        if (command.includes(addCmd)) {
            const name = command.substring(9);
            const movie = { name };
            movies.push(movie);

        } else if (command.includes(directedByCmd)) {
            const [name, director] = command.split(` ${directedByCmd} `);
            const movie = movies.find(m => m.name == name);
            if (movie != undefined) {

                movie.director = director;
            }

        } else if (command.includes(onDateCmd)) {
            const [name, date] = command.split(` ${onDateCmd} `);
            const movie = movies.find(m => m.name == name);
            if (movie != undefined) {
                movie.date = date;
            }
        }
    }

    movies
        .filter(m => m.director && m.date)
        .forEach(m => console.log(JSON.stringify(m)));
}
solve([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
]
);