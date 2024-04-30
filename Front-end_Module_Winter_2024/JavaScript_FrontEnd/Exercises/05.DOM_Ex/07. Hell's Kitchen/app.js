function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      //   TODO:
      const textareaElement = document.querySelector('#inputs textarea');
      const matches = Array.from(textareaElement.value.matchAll(/"(?<name>\w+) - (?<staff>.*)"/g));

      let restaurants = {};
      for (let match of matches) {
         const name = match[1];
         let workers = Array.from(match[2]
            .split(', ')
            .map(w => {
               [workerName, salary] = w.split(' ');
               return { name: workerName, salary: Number(salary) };
            }));

         if (restaurants.hasOwnProperty(name)) {
            restaurants[name][workers].concat(workers);
         } else {
            restaurants[name] = { name, workers };
         }
      }
      console.log(restaurants);

      //Calculate data:
      let bestRestaurant = { averageSalary: 0 };
      for (let restaurant in restaurants) {
         const restaurantObj = restaurants[restaurant];
         const salaries = Array.from(restaurantObj.workers.map(w => w.salary));

         averageSalary = salaries
            .reduce((sum, s) => sum + s, 0) / salaries.length;

         const bestSalary = Math.max(...Array.from(restaurantObj.workers.map(w => w.salary)));
         restaurantObj.averageSalary = averageSalary;
         restaurantObj.bestSalary = bestSalary;
         if (averageSalary > bestRestaurant.averageSalary) {
            bestRestaurant = restaurantObj;
         }
      }

      //Print output:
      const restaurantOutputElement = document.querySelector('#outputs #bestRestaurant p');
      const workersOutputElement = document.querySelector('#outputs #workers p');

      const bestRestaurantOutput = `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.averageSalary.toFixed(2)} Best Salary: ${bestRestaurant.bestSalary.toFixed(2)}`;
      restaurantOutputElement.textContent = bestRestaurantOutput;

      let workersString = '';
      for (const worker of bestRestaurant.workers) {
         workersString += `Name: ${worker.name} With Salary: ${worker.salary} `;
      }
      workersOutputElement.textContent = workersString.trimEnd();
   }
}