class Board {

    constructor() {
        this.cards = [];
        this.unique_Images = ['image/bag.png', 'image/headset.png', 'image/laptop-image.png',
            'image/laptop.png', 'image/title_logo.jpg', 'image/statrs.png',
            'image/kiwi.png', 'image/mango.png']
        this.image_set = [...this.unique_Images, ...this.unique_Images];
        this.container = document.querySelector('.container');
        this.logic = new GameLogic();

        this.OpenCards = [];
        this.Open_Card_Count = 0;
        this.locked = false;
    }

    createBoard() {
        this.image_set = this.logic.shuffleImages(this.image_set, this.image_set.length);
        this.image_set.forEach((element, index) => {
            let card = new Card(index + 1, element, this.logic);
            this.cards.push(card);
            this.container.appendChild(card.render());
            
        });

    }

}
