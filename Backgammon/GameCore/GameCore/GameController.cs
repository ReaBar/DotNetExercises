using System;

namespace GameCore
{
    public enum GameCheckers
    {
        White,
        Red,
        Empty
    }

    public class GameController : IGameController
    {
        private Move _gameMove;
        private IBoardState _gameBoard;
        private IPlayer _whitePlayer;
        private IPlayer _redPlayer;
        private GameCheckers _turn;

        public GameController(IPlayer whitePlayer, IPlayer redPlayer)
        {
            _gameBoard = new GameBoard();
            _whitePlayer = whitePlayer;
            _redPlayer = redPlayer;
            _gameMove = new Move(_gameBoard);
        }

        public IBoardState GameBoardState => _gameBoard;

        public void StartNewGame()
        {
            
        }
    }
}
