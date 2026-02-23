let numbers = [3, 7, 12, 5, 9];
for (let i = 0; i < numbers.length; i++) {
      if(numbers[i] === 12){
               console.log("Number 12 found, stopping the loop");
                break;
       }
       console.log(numbers[i]);
}

