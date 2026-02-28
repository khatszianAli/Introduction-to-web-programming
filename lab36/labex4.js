function counter(){
    let count = 0;
    return function (){
        count+=1;
        return count;
    }
}

const count1 = counter();
console.log(count1());
console.log(count1());


const count2 = counter();
console.log(count2());
