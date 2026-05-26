document.addEventListener('DOMContentLoaded', function () {
    const Board = document.getElementById("Board");
    const board = new BoardClass();
    board.createBoard();

    const elmts = new elements();
    elmts.whiteCoinsElement();

    let coins = ['rook', 'knight', 'bishops', 'king',
        'queen', 'bishops', 'knight', 'rook',
        'pawns', 'pawns', 'pawns', 'pawns',
        'pawns', 'pawns', 'pawns', 'pawns'];


    localStorage.setItem("ChessCoins", JSON.stringify(coins));

});

class BoardClass {
    createBoard() {
        for (let i = 0; i < 9; i++) {
            let row = document.createElement('tr');
            row.classList.add('row-style');
            for (let j = 0; j < 9; j++) {

                //Top Header
                if (i == 0) {
                    let cell = document.createElement('div');
                    row.appendChild(cell);
                    cell.innerText = j;
                    cell.classList.add('upsideindex');
                }
                else {
                    let cell = document.createElement('div');
                    row.appendChild(cell);
                    cell.classList.add('cell-style');

                    // Left Header
                    if (j == 0) {
                        cell.innerText = i;
                        cell.classList.add('leftsideindex');
                    }

                    else {
                        if (i % 2 == 0) {
                            if (j % 2 == 0) { cell.classList.add('cell-blackcolor'); }
                            else { cell.classList.add('cell-whitecolor'); }
                        }
                        else {
                            if (j % 2 == 1) { cell.classList.add('cell-blackcolor'); }
                            else { cell.classList.add('cell-whitecolor'); }
                        }
                    }
                }

            }
            Board.appendChild(row);
        }
    }

    assignCoins() {
        let coins = []
    }

}
class elements {
    constructor() {
        this.board = this.boardelements();
        this.whiteCoins = this.whiteCoinsElement();
        this.BlackCoins = [];
    }


    boardelements() {
        let Board_elements = [8][8];
    }

    whiteCoinsElement() {
        let whiteCoinsElements;
        let data = JSON.parse(localStorage.getItem("ChessCoins"));
        console.log(data);
        for (let k = 0; k < data.length; k++) {
            for (let i = 0; i < 2; i++) {
                for (let j = 0; j < 8; j++) {
                    whiteCoinsElements[i][j] = data[k];
                }
            }
        }


    }

}