class Card{
    constructor(id, imgSrc, logic){
        this.id = id;
        this.imgSrc = imgSrc;
        this.isFlip = false;
        this.isMatched = false;
        this.element = null;
        this.logic = logic;
        
    }
    
    render(){
        let cardcell = document.createElement('div');
        cardcell.classList.add('box-style');

        let cardImg =  document.createElement('img');
        cardImg.src = this.imgSrc;
        cardcell.classList.add('img');
        
        cardcell.appendChild(cardImg);
        this.element = cardcell;

        cardcell.addEventListener("click", ()=>
            this.logic.flip(this)
        );
        return cardcell;  
      }
}




