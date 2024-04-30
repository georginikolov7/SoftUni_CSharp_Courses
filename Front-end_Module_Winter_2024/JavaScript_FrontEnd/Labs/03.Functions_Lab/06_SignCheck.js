function checkSignOfMultiplication(n1,n2,n3){
    let negativesCount=0;
    for(let number of arguments){
        if(number<0){
            negativesCount++;
        }
    }
    if(negativesCount%2==0){
        console.log('Positive');
    }else{
        console.log('Negative');
    }
}