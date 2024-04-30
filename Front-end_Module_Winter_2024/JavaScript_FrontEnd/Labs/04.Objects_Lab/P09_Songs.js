function solve(input) {
    class Song {
        constructor(name, time) {
            this.name = name;
            this.time = time;
        }

    }
    const count = input.shift();
    const command = input.pop();
    const collections = {};
    const allSongs = [];

    for (const line of input) {
        const [typeList, name, time] = line.split('_');
        const song = new Song(name, time);

        if (!collections[typeList]) {
            collections[typeList] = [];
        }
        collections[typeList].push(song);
        allSongs.push(song);
    }

    if (command === 'all') {
        allSongs
            .forEach(s => console.log(`${s.name}`));

    } else {
        collections[command]
            .forEach(song => console.log(`${song.name}`));
    }
}