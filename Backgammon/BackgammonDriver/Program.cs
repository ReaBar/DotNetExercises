using GameCore;
using UICore;

namespace BackgammonDriver
{
    public class Program
    {
        static void Main(string[] args)
        {
            IPlayer whitePlayer = new HumanPlayer(GameCheckers.White);
            IPlayer redPlayer = new HumanPlayer(GameCheckers.Red);
            IGameController gameController = new GameController(whitePlayer,redPlayer);
            IUiController uiController = new UiController(gameController);
            uiController.StartGame();
        }
    }
}
