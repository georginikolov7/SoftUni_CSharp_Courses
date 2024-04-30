function solve(number){
    let temp=number;
    let sum=0;
while(temp>0){
    sum+=temp%10;
    temp= Math.floor(temp/10);
}
console.log(sum);
}