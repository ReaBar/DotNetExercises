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
        private IPlayer _currentPlayer;

        public GameController(IPlayer whitePlayer, IPlayer redPlayer)
        {
            _dice = new Dice();
            _gameBoard = new BoardState();
            _whitePlayer = whitePlayer;
            _redPlayer = redPlayer;
            _gameMove = new Move(_gameBoard);
        }
        public int FirstDice => _dice.FirstDice;
        public int SecondDice => _dice.SecondDice;
        public int RollFirstDice => _dice.RollFirstDice;
        public int RollSecondDice => _dice.RollSecondDice;

        public IBoardState GameBoardState => _gameBoard;

        public IPlayer CurrentPlayer => _currentPlayer;

        public void SetFirstPlayer(GameCheckers player)
        {
            if (player.Equals(GameCheckers.White))
            {
                _currentPlayer = _whitePlayer;
            }

            else
            {
                _currentPlayer = _redPlayer;
            }
        }

        public bool MakeMove(IPlayer player, int source, int destination)
        {
            if (player.GameCheckerColor.Equals(GameCheckers.White))
            {
                if (source - destination != FirstDice || source - destination != SecondDice)
                {
                    return false;
                }
            }

            if (player.GameCheckerColor.Equals(GameCheckers.Red))
            {
                if (destination - source != FirstDice || destination - source != SecondDice)
                {
                    return false;
                }
            }
            source--;
            destination--;
            int numOfTurns = 2;
            if (FirstDice == SecondDice)
            {
                numOfTurns = 4;
            }

            if (_gameMove.IsMoveLegal(_gameBoard, player, source, destination))
            {
                numOfTurns--;
                _gameBoard = _gameMove.MakeMove(_gameBoard, player, source, destination);
                if (numOfTurns == 0)
                {
                    _currentPlayer = player == _whitePlayer ? _redPlayer : _whitePlayer;
                }
                return true;
            }
            return false;
        }

    }
}
