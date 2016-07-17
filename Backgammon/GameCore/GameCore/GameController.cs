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

        //private bool MakeMove(IPlayer player, int source, int destination)
        //{
        //    if (player.GameCheckerColor.Equals(GameCheckers.White))
        //    {
        //        if (source - destination != FirstDice && source - destination != SecondDice)
        //        {
        //            return false;
        //        }
        //    }

        //    if (player.GameCheckerColor.Equals(GameCheckers.Red))
        //    {
        //        if (destination - source != FirstDice && destination - source != SecondDice)
        //        {
        //            return false;
        //        }
        //    }

        //    if (_gameMove.IsMoveLegal(_gameBoard, player, source, destination))
        //    {
        //        _gameMove.NumOfTurnsLeft--;
        //        _gameBoard = _gameMove.MakeMove(_gameBoard, player, source, destination);
        //        if (_gameMove.NumOfTurnsLeft == 0)
        //        {
        //            _currentPlayer = player == _whitePlayer ? _redPlayer : _whitePlayer;
        //        }
        //        return true;
        //    }
        //    return false;
        //}

        public bool MakeMove(IPlayer player, object source, object destination)
        {

            int intSource = 0, intDestination = 0;
            string strSource = null, strDestination = null;
            if (source == null || destination == null)
            {
                return false;
            }

            if (!_gameMove.IsMoveLegal(_gameBoard, player, source, destination))
            {
                return false;
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

            //switch (player.PlayerState)
            //{
            //    case PlayerCondition.Regular:
            //        if (player.GameCheckerColor.Equals(GameCheckers.White))
            //        {
            //            if (intSource - intDestination != FirstDice && intSource - intDestination != SecondDice)
            //            {
            //                return false;
            //            }
            //        }

            //        if (player.GameCheckerColor.Equals(GameCheckers.Red))
            //        {
            //            if (intDestination - intSource != FirstDice && intDestination - intSource != SecondDice)
            //            {
            //                return false;
            //            }
            //        }
            //        break;

            //    case PlayerCondition.Bar:
            //        if (player.GameCheckerColor.Equals(GameCheckers.Red))
            //        {
            //            if (_dice.FirstDice != intDestination && _dice.SecondDice != intDestination)
            //            {
            //                return false;
            //            }
            //        }

            //        else if (player.GameCheckerColor.Equals(GameCheckers.White))
            //        {
            //            if (_dice.FirstDice != ((24+1) - intDestination) && _dice.SecondDice != ((24 + 1) - intDestination))
            //            {
            //                return false;
            //            }
            //        }
            //        break;

            //    case PlayerCondition.BearingOff:
            //        //TODO do I need to check for something special?
            //        break;

            //    default:
            //        return false;
            //}

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

            if (source is string && destination is int)
            {
                _gameBoard = _gameMove.MakeMove(_gameBoard,player,strSource,intDestination-1);
                WhosTurn(player, _gameMove.NumOfTurnsLeft);
                return true;
            }

            return false;
        }

        private void WhosTurn(IPlayer player, int numOfTurns)
        {
            _gameMove.NumOfTurnsLeft--;
            if (_gameMove.NumOfTurnsLeft == 0 || numOfTurns == 0)
            {
                _currentPlayer = player == _whitePlayer ? _redPlayer : _whitePlayer;
            }
        }

        //private bool MakeMoveFromBar(IPlayer player, string source, int destination)
        //{
        //    if (_gameBoard.GameCheckersOnBar.Contains(player.GameCheckerColor))
        //    {
        //        if (player.GameCheckerColor.Equals(GameCheckers.Red))
        //        {
        //            if (_dice.FirstDice != destination && _dice.SecondDice != destination)
        //            {
        //                return false;
        //            }
        //        }

        //        else if (player.GameCheckerColor.Equals(GameCheckers.White))
        //        {
        //            if (_dice.FirstDice != (24 - destination) && _dice.SecondDice != (24 - destination))
        //            {
        //                return false;
        //            }
        //        }

        //        _gameMove.NumOfTurnsLeft--;
        //        _gameBoard = _gameMove.MakeMove(_gameBoard, player, source, destination);
        //        if (_gameMove.NumOfTurnsLeft == 0)
        //        {
        //            _currentPlayer = player == _whitePlayer ? _redPlayer : _whitePlayer;
        //        }
        //        return true;
        //    }

        //    return false;
        //}

        //public bool MakeMove(IPlayer player, int source, string destination)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
