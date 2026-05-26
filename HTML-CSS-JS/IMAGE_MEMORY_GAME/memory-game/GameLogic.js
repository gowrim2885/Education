class GameLogic {

    constructor() {
        this.open_cards = [];
        this.MatchedCards = [];
        this.locked = false;
        this.startTime=60;
    }

    shuffleImages(image_set, len) {
        for (let i = len - 1; i > 0; i--) {
            let j = Math.floor(Math.random() * (i + 1));
            const temp = image_set[i];
            image_set[i] = image_set[j];
            image_set[j] = temp;
        }
        return image_set;
    }

    flip(card) {
        if (this.locked || card.isFlip || card.isMatched) {
            return;
        }
     
            card.element.classList.add('flip');
            card.isFlip = !card.isFlip;

            this.open_cards.push(card);


            if (this.open_cards.length === 2) {
                this.checkMatch();
            }

        }
  

    checkMatch() {
        this.locked = true;
        let [card1, card2] = this.open_cards;
        if (card1.imgSrc === card2.imgSrc) {
            card1.isMatched = true;
            card2.isMatched = true;
            this.MatchedCards.push(card1);
            this.MatchedCards.push(card2);
            card1.element.classList.add('matched');
            card2.element.classList.add('matched');
            this.checkResult();
            this.reset();
        }
        else {
            setTimeout(() => {
                card1.element.classList.remove('flip');
                card2.element.classList.remove('flip');

                card1.isFlip = !card1.isFlip;
                card2.isFlip = !card2.isFlip;
                this.reset();
            }, 1000);
        }
    }

    reset() {
        this.open_cards = [];
        this.locked = false;
    }

    checkResult() {
        if (this.MatchedCards.length == 16) {
            let result = document.getElementById('result');
            result.innerHTML = "Congratulation! Yor are the Winner!!!";
            

        }
    }

    checkTime() {
        let start = document.getElementById("start");
        start.addEventListener('click', () => this.checkTimer(this.startTime));
    }

    checkTimer(i) {
        let displayTime = document.getElementById("timer");
        displayTime.innerHTML = i;
        i--;
        if (i < 0) {
            result.innerHTML = `<h5>Time Out.....You Lose! <br> Try Again.`;
            return;
        }
        else {
            setTimeout(()=>{
                this.checkTimer(i)}, 1000);
        }
    }

}

