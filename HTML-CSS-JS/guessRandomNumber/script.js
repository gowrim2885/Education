document.addEventListener('DOMContentLoaded',()=>{

    const result = document.getElementById("finalResult");
    const subButton = document.getElementById("submit_btn");
    const remainder = document.getElementById("remain");
   
    let count=0;
    let total_chance =3;
    let Guessing_number =  Math.round(Math.random() *10);

    subButton.addEventListener('click', (event)=>{
        event.preventDefault();
       
        let userInput = Number(document.getElementById("InputNumber").value);
        
        if(userInput<0 || isNaN(userInput) || userInput<=0 || userInput>10){
            alert("Enter valid input value");
            return;
        }

        count++;
        if(Guessing_number == userInput){
            result.textContent = "Correct Answer!!!";
            subButton.disabled = true;
            remainder.innerHTML= " ";
            document.getElementById("InputNumber").disabled = true;
              
        }

        else if(Guessing_number>userInput){
            result.textContent = "Wrong answer,  your ans is Low, the gussing number is High!!!";
        }

        else{
            result.textContent = "Wrong answer, your ans is High, the gussing number is Low!!!";
        }

        let remain_count = total_chance - count;

        if(userInput!== Guessing_number && remain_count > 0){
            remainder.innerHTML= `try again, You hav remaining ${remain_count} chance`;
            document.getElementById("InputNumber").value="";
            document.getElementById("InputNumber").focus();
        }

        if(userInput!== Guessing_number && remain_count == 0){
            remainder.innerHTML=" ";
            result.textContent = ` Game Over! the Guessing number is ${Guessing_number}`;
            subButton.disabled = true;
            document.getElementById("InputNumber").disabled = true;
        }
    }); 

});


function resetBtn(){
    window.location.reload();
}