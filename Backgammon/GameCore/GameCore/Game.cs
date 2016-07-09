
namespace GameCore
{
    class Game
    {
        private Move _gameMove;
        private IBoardState _gameBoard = new GameBoard();
        private IPlayer _whitePlayer;
        private IPlayer _blackPlayer;

        public Game(IPlayer player1, IPlayer player2)
        {
            _whitePlayer = player1;
            _blackPlayer = player2;
            _gameMove = new Move(_gameBoard);
        }
    }
}
