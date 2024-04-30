function solve(nums){
    let evenSum=0;
    let oddSum=0;
    for(let i=0;i<nums.length;i++){
        if(nums[i]%2==0){
            evenSum+=Number(nums[i]);
        }else{
            oddSum+=Number(nums[i]);
        }
    }
    console.log(evenSum-oddSum);
}
solve([3,5,7,9]);