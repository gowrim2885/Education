import Card from './user_interaction.js';


export default class Board{

    createBoard(){
        let cards = [
            new Card("1",'image/bag.png', "Bag","false"),
            new Card("2", 'image/headset.png', "Heatset","false"),
            new Card("3", 'image/laptop-image.png', "Laptop","false"),
            new Card("4", 'image/laptop.png', "Lap","false"),
            new Card("5", 'image/title_logo.jpg', "Logo","false"),
            new Card("6", 'image/statrs.png', "Stare","false"),
            new Card("7", 'image/kiwi.png', "Kiwi","false"),
            new Card("8", 'image/mango.png',"Mango","false"),
            new Card("9",'image/bag.png', "Bag", "false"),
            new Card("10", 'image/headset.png', "Heatset", "false"),
            new Card("11", 'image/laptop-image.png', "Laptop", "false"),
            new Card("12", 'image/laptop.png', "Lap", "false"),
            new Card("13", 'image/title_logo.jpg', "Logo", "false"),
            new Card("14", 'image/statrs.png', "Stare", "false"),
            new Card("15", 'image/kiwi.png', "Kiwi", "false"),
            new Card("16", 'image/mango.png',"Mango", "false"),
        ];

        let board = document.querySelector('.container');
        board.innerHTML = "";

        cards.forEach(card => {
            let cell = document.createElement('div');
            cell.id = card.id;
            cell.name = card.name;
            cell.className='box-style';
            cell.setAttribute('isActive', card.isActive);

            const img = document.createElement('img');
            img.src = card.src;
            img.alt =  card.name;
            img.id = card.id;
            

            board.appendChild(cell);
            cell.appendChild(img);
        });

        

    }
}



document.addEventListener('DOMContentLoaded', () => {
  const obj1 = new Board();
  obj1.createBoard();
});



document.addEventListener('click',openCard);
function openCard(e){
    let openItem=[];

    let status = e.target.getAttribute('isActive');


    let current_img_id = e.target.id;

    let element = document.getElementById(current_img_id);
    if(status == "false"){
        element.classList.add('show');
        e.target.setAttribute('isActive', 'true');
        openItem.push(e.target.name);
        console.log(e.target.name);

    }
    else{
        element.classList.remove('show');
        console.log(e.target);
        e.target.setAttribute('isActive', 'false');
    }
}

//   if(openItem[0].name == openItem[1].value ){
//         console.log("same");

//     }
//     else{
//         console.log("Not Same");
//         openItem.length =0;
//     }
