
function solve(input) {
    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = Number(age);
        }

        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }

    const result = input
        .map(line => line.split(" "))
        .map(kvp => new Cat(...kvp))
        .forEach(cat => cat.meow());
}