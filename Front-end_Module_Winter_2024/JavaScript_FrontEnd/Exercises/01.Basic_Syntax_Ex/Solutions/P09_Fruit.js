function solve(type,quantity,price){
    let kg=quantity/1000;
    let total=price*kg;
    console.log(`I need \$${total.toFixed(2)} to buy ${kg.toFixed(2)} kilograms ${type}.`);
}