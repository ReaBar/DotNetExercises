using System;

namespace GameCore
{
    public enum PlayerCondition
    {
        Regular,
        Bar,
        BearingOff
    }

    public enum GameCheckers
    {
        White,
        Red,
        Empty
    }

    public class GameController : IGameController
    {
        private readonly Move _gameMove;
        private IBoardState _gameBoard;
        private IPlayer _whitePlayer;
        private IPlayer _redPlayer;
        private readonly Dice _dice;
        private int _firstDice, _secondDice;

        public GameController(IPlayer whitePlayer, IPlayer redPlayer)
        {
            _dice = new Dice();
            _gameBoard = new BoardState();
            _whitePlayer = whitePlayer;
            _redPlayer = redPlayer;
            _gameMove = new Move(_gameBoard);
        }

        public int RollFirstDice()
        {
            _firstDice = _dice.FirstDice;
            return _firstDice;
        }

        public int RollSecondDice()
        {
            _secondDice = _dice.SecondDice;
            return _secondDice;
        }

        public IBoardState GameBoardState => _gameBoard;

        public IBoardState MakeMove(IBoardState boardState,IPlayer player, int source, int destination)
        {
            _gameBoard =_gameMove.MakeMove(_gameBoard,player,source,destination);
            return _gameBoard;
        }

        public GameCheckers WhosTurn { get; set; }
    }
}
