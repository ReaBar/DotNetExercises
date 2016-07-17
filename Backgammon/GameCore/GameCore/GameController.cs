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
        private readonly IPlayer _whitePlayer;
        private readonly IPlayer _redPlayer;
        private IPlayer _currentPlayer;
        private readonly Dice _dice;

        public GameController(IPlayer whitePlayer, IPlayer redPlayer)
        {
            _dice = new Dice();
            _gameBoard = new BoardState();
            _whitePlayer = whitePlayer;
            _redPlayer = redPlayer;
            _gameMove = new Move(_gameBoard,_dice);
        }

        public int FirstDice => _dice.FirstDice;
        public int SecondDice => _dice.SecondDice;
        public int RollFirstDice => _dice.RollFirstDice;
        public int RollSecondDice => _dice.RollSecondDice;

        public IBoardState GameBoardState => _gameBoard;

        public IPlayer CurrentPlayer => _currentPlayer;

        public void SetFirstPlayer(GameCheckers player)
        {
            _currentPlayer = player.Equals(GameCheckers.White) ? _whitePlayer : _redPlayer;
        }

        public void TurnStarts()
        {
            var dice1 = _dice.RollFirstDice;
            var dice2 = _dice.RollSecondDice;
            _gameMove.NumOfTurnsLeft = dice1 == dice2 ? 4 : 2;
        }

        public bool AnyPossibleMoves => PossibleMoves();

        public int NumOfTurnsLeft => _gameMove.NumOfTurnsLeft;

        private bool PossibleMoves()
        {
            _gameMove.PossibleMoves(_currentPlayer,_dice.FirstDice,_dice.SecondDice);
            if (_gameMove.GetBarPossibleMoves.Count != 0 || _gameMove.GetInboardPossibleMoves.Count != 0)
            {
                return true;
            }
            WhosTurn(_currentPlayer,0);
            return false;
        }

        public bool MakeMove(IPlayer player, object source, object destination)
        {

            int intSource = 0, intDestination = 0;
            string strSource = null, strDestination = null;
            if (source == null || destination == null)
            {
                return false;
            }

            bool isMoveLegal = _gameMove.IsMoveLegal(_gameBoard, player, source, destination);

            if (!isMoveLegal)
            {
                return false;
            }

            if (isMoveLegal)
            {
                var move = 0;
                if (player.GameCheckerColor.Equals(GameCheckers.Red))
                {
                    switch (player.PlayerState)
                    {
                        case PlayerCondition.Regular:
                            move = (int) destination - (int) source;
                            break;
                        case PlayerCondition.Bar:
                            move = (int) destination;
                            break;
                        case PlayerCondition.BearingOff:
                            move = 25 - (int)source;
                            break;
                    }
                }

                else
                {
                    switch (player.PlayerState)
                    {
                        case PlayerCondition.Regular:
                            move = (int)source - (int)destination;
                            break;
                        case PlayerCondition.Bar:
                            move = 25 - (int)destination;
                            break;
                        case PlayerCondition.BearingOff:
                            move = (int)source;
                            break;
                    }
                }

                if (move != 0 && _dice.FirstDice != _dice.SecondDice)
                {
                    if ((move == _dice.FirstDice && _dice.FirstDicePlayed) || (move == _dice.SecondDice && _dice.SecondDicePlayed))
                    {
                        return false;
                    }

                    if (move == _dice.FirstDice)
                    {
                        _dice.FirstDicePlayed = true;
                    }

                    else if (move == _dice.SecondDice)
                    {
                        _dice.SecondDicePlayed = true;
                    }
                }
            }

            var s1 = source as string;
            if (s1 != null)
            {
                strSource = s1;
                intDestination = (int)destination;
            }

            var s = destination as string;
            if (s != null)
            {
                strDestination = s;
                intSource = (int) source;
            }

            if (s1 == null && s == null)
            {
                intDestination = (int)destination;
                intSource = (int) source;
            }

            if (source is int && destination is int)
            {
                _gameBoard = _gameMove.MakeMove(_gameBoard,player, intSource - 1, intDestination - 1);
                WhosTurn(player,_gameMove.NumOfTurnsLeft);
                return true;
            }

            if (source is int && destination is string)
            {
                _gameBoard = _gameMove.MakeMove(_gameBoard,player,intSource-1,strDestination);
                WhosTurn(player, _gameMove.NumOfTurnsLeft);
                return true;
            }

            if (!(source is string) || !(destination is int)) return false;
            _gameBoard = _gameMove.MakeMove(_gameBoard,player,strSource,intDestination-1);
            WhosTurn(player, _gameMove.NumOfTurnsLeft);
            return true;
        }

        private void WhosTurn(IPlayer player, int numOfTurns)
        {
            _gameMove.NumOfTurnsLeft--;
            if (_gameMove.NumOfTurnsLeft == 0 || numOfTurns == 0)
            {
                _currentPlayer = player == _whitePlayer ? _redPlayer : _whitePlayer;
                _dice.FirstDicePlayed = false;
                _dice.SecondDicePlayed = false;
            }
        }
    }
}
