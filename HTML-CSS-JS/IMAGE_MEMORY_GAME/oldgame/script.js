let count=0;
let point=0;
let imageSet = [
    'image/bag.png', 'image/headset.png', 'image/laptop-image.png',
     'image/laptop.png','image/title_logo.jpg', 'image/statrs.png',
     'image/kiwi.png', 'image/mango.png' 
];

let boxValue = [0,0,0,0,
                0,0,0,0,
                0,0,0,0,
                0,0,0,0];

let points = document.getElementById('score');
createBoard();

function createBoard(){
    const board = document.querySelector(".container");
    board.innerHTML="";

    let pairedImages = [];
    imageSet.forEach(img => {
        pairedImages.push(img);
        pairedImages.push(img);
    });


    pairedImages.sort(() => Math.random() - 0.5);

    for(let i=0; i<16; i++){
        let box = document.createElement('div');
        box.className = 'box-style';
        box.id = `${i+1}`;
        box.value = boxValue[i];

        const imagetag = document.createElement('img');
        imagetag.src = pairedImages[i];
        imagetag.id="boximg";
        imagetag.alt = "Grid-Image";
        imagetag.className ="box-image";

        board.appendChild(box);
        box.appendChild(imagetag);

            
        box.addEventListener("click", function(event) {
            const target = event.currentTarget;
            console.log(target.id);
            if (target.value == 0) {
                target.classList.add("show");
                target.value = 1;
                boxValue[target.id -1]=1;
                console.log(boxValue);

            } else {
                target.classList.remove("show");
                target.value = 0;
                boxValue[target.id -1]=0;
                console.log(boxValue);

            }
            checkResult(event);
        });

    }
}


let presentposition=[];
let usedPositions=[];


function checkResult(event) {
    const img = event.target;
   
    for(let i=0; i< boxValue.length;i++){
        if (boxValue[i] === 1) {
            if(usedPositions.includes(i)){
                continue;
            }
            else{
                presentposition.push(i);
                count++;
            }
            
        }
    }

    
    

    if (count >= 2) {
        let firstitem = presentposition[0];
        let seconditem = presentposition[1];

        let box1 = document.getElementById(firstitem + 1);
        let box2 = document.getElementById(seconditem + 1);

        let img1 = box1.querySelector('img');
        let img2 = box2.querySelector('img');

        if (img1.src == img2.src) {
            console.log("Both images are same");
            point++;
            points.innerHTML = point;
            box1.classList.add("matched");
            box2.classList.add("matched");

            usedPositions.push(firstitem, seconditem);
            presentposition.length=0;
            count = 0;

        }
         else {
            setTimeout(()=>{
                box1.classList.remove("show");
                box2.classList.remove("show");
                boxValue[firstitem]=0;
                boxValue[seconditem]=0;
            },800);
            presentposition.length=0;
            count = 0;
        }

        
    }
    else{
        count=0;
        presentposition.length=0;
    }

    if(usedPositions.length == 16){
        console.log("Completed");

    }
}


