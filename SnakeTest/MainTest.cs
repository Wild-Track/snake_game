using Snake;
// Use for exception : CustomCheatingPlayerException
using static Snake.Game;

namespace SnakeTest
{
    [TestClass]
    public class MainTest
    {
        private Player testPlayer1;
        private Player testPlayer2;
        private Game testGame;

        [TestInitialize]
        public void Init()
        {
            testPlayer1 = new Player("1");
            testPlayer2 = new Player("2");
            testGame = new Game(testPlayer1, testPlayer2);
        }


        // Test for Dice class
        [TestMethod]
        [DataRow(1, 7)]
        public void Dice_CheckInitOfDice_ShouldBeFine(int minimum, int maximum)
        {
            Dice dice = new Dice(minimum, maximum);

            Assert.AreEqual(minimum, dice.minimum);
            Assert.AreEqual(maximum, dice.maximum);
        }

        [TestMethod]
        [DataRow(-1, 7)]
        [DataRow(6, 1)]
        public void Dice_CheckInitOfDice_ShouldThrowArgumentException(int minimum, int maximum)
        {
            Assert.ThrowsException<ArgumentException>(() => new Dice(minimum, maximum));
        }


        // Test for Player class
        [TestMethod]
        [DataRow("Test")]
        public void Player_CheckInit(string name)
        {
            Player player = new Player(name);

            Assert.AreEqual(0, player.score);
            Assert.AreEqual(name, player.name);
        }

        [TestMethod]
        public void Player_checkInit_ShouldThrowArgumentException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new Player(null));
        }

        [TestMethod]
        public void Player_PlayRound()
        {
            testPlayer1.PlayRound();

            Assert.AreEqual(testPlayer1.score, testPlayer1.dice.lastNumber);
        }

        [TestMethod]
        public void Player_PrintRound()
        {
            testPlayer1.PlayRound();

            Assert.AreEqual(testPlayer1.RoundToString(), string.Format("Joueur : {0} son score est : {1}", testPlayer1.name, testPlayer1.score));
        }


        // Test for Game class
        [TestMethod]
        public void Game_CheckInit_ShouldThrowCustomCheatingPlayerException()
        {
            Player player1 = new Player("1");
            Player player2 = new Player("2");
            player1.score = 50;
            
            Assert.ThrowsException<CustomCheatingPlayerException>(() => new Game(player1, player2));
        }

        [TestMethod]
        public void Game_CheckInit_ShouldThrowArgumentNullException()
        {
            Player player1 = null;
            Player player2 = new Player("2");

            Assert.ThrowsException<ArgumentNullException>(() => new Game(player1, player2));
        }

        [TestMethod]
        public void Game_CheckInit_ShouldCreateGame()
        {
            Player player1 = new Player("1");
            Player player2 = new Player("2");
            Game game = new Game(player1, player2);

            Assert.IsTrue(game.players.Contains(player1));
            Assert.IsTrue(game.players.Contains(player2));
        }

        [TestMethod]
        public void Game_UpdateGameStatus_ShouldSetScoreTo25()
        {
            testPlayer1.score = 51;
            testGame.playerTurn = 0;
            testGame.UpdateGameStatus();

            Assert.AreEqual(testPlayer1.score, 25);
            Assert.AreEqual(testGame.playerTurn, 1);
        }

        [TestMethod]
        public void Game_UpdateGameStatus_ShouldKeepPlayerTurn()
        {
            // Set score to 10 which is a bonus score
            testPlayer1.score = 10;
            testGame.playerTurn = 0;
            testGame.UpdateGameStatus();

            Assert.AreEqual(testGame.playerTurn, 0);
            Assert.AreEqual(testPlayer1.score, 10);
        }

        [TestMethod]
        public void Game_UpdateGameStatus_ShouldChangeTurn()
        {
            testPlayer1.score = 6;
            testGame.playerTurn = 0;
            testGame.UpdateGameStatus();

            Assert.AreEqual(testGame.playerTurn, 1);
            Assert.AreEqual(testPlayer1.score, 6);
        }

        [TestMethod]
        public void Game_UpdateGameStatus_ShouldSetGameEndedToTrue()
        {
            testPlayer1.score = 50;
            testGame.playerTurn = 0;
            testGame.UpdateGameStatus();

            Assert.AreEqual(testGame.playerTurn, 0);
            Assert.AreEqual(testGame.gameEnded, true);
            Assert.AreEqual(testGame.winner, testPlayer1);
        }

        [TestMethod]
        public void Game_Win_ShouldOutputWinner()
        {
            // Change stdout to capture the output of Console.WriteLine()
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            testPlayer1.score = 50;
            testGame.playerTurn = 0;
            testGame.UpdateGameStatus();

            testGame.Win();

            Assert.AreEqual(string.Format("Le joueur : {0} à gagné\r\n", testGame.winner.name), stringWriter.ToString());
        }
    }
}