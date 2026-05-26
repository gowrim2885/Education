document.addEventListener('DOMContentLoaded', function(){
    const BoardData = new Board();
    BoardData.createBoard();

    const logic = new GameLogic();
    logic.checkTime();
  
});